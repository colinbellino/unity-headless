using System;
using System.Collections.Generic;
using Greed.Core;
using Greed.Core.StateMachines.Door;
using Zenject;
using static Greed.Core.StateMachine;

namespace Greed.Unity
{
	public class DoorInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			InstallStateMachine();
		}

		private void InstallStateMachine()
		{
			Container.BindInterfacesAndSelfTo<ClosingState>().AsSingle();
			Container.BindInterfacesAndSelfTo<OpeningState>().AsSingle();

			var transitions = new Dictionary<Type, Transitions>
				{ //
					{ typeof(ClosingState), new Transitions { { "Toggle", typeof(OpeningState) } } },
					{ typeof(OpeningState), new Transitions { { "Toggle", typeof(ClosingState) } } },
				};
			Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle()
				.WithArguments(transitions);
		}
	}
}
