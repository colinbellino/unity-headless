using System;
using System.Collections.Generic;
using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class PlayerInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();

			InstallStateMachine();
		}

		private void InstallStateMachine()
		{
			Container.BindInterfacesAndSelfTo<EntityIdleState>().AsSingle();
			Container.BindInterfacesAndSelfTo<EntityEncumberedState>().AsSingle();

			var transitions = new Dictionary<Type, StateMachine.Transitions>
				{ //
					{ typeof(EntityIdleState), new StateMachine.Transitions { { "PickUp", typeof(EntityEncumberedState) } } },
					{ typeof(EntityEncumberedState), new StateMachine.Transitions { { "Throw", typeof(EntityIdleState) } } }
				};
			Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle()
				.WithArguments(transitions);
		}
	}
}
