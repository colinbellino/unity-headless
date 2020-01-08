using System;
using System.Collections.Generic;
using Greed.Core;
using Greed.Core.StateMachines.Button;
using UnityEngine;
using Zenject;
using static Greed.Core.StateMachine;

namespace Greed.Unity
{
	public class PressurePlateInstaller : MonoInstaller
	{
		[SerializeField] private string _activationColliderTag = "PhysicsCollider";

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PressureActivation>().AsSingle()
				.WithArguments(_activationColliderTag);

			InstallStateMachine();
		}

		private void InstallStateMachine()
		{
			Container.BindInterfacesAndSelfTo<InactiveState>().AsSingle();
			Container.BindInterfacesAndSelfTo<OnState>().AsSingle();
			Container.BindInterfacesAndSelfTo<OffState>().AsSingle();

			var transitions = new Dictionary<Type, Transitions>
				{ //
					{ typeof(InactiveState), new Transitions { { "Activate", typeof(OffState) } } },
					{ typeof(OnState), new Transitions { { "Toggle", typeof(OffState) }, { "Deactivate", typeof(InactiveState) } } },
					{ typeof(OffState), new Transitions { { "Toggle", typeof(OnState) }, { "Deactivate", typeof(InactiveState) } } },
				};
			Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle()
				.WithArguments(transitions);
		}
	}
}
