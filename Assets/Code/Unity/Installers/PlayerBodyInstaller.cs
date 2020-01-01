using System;
using System.Collections.Generic;
using Greed.Core;
using Greed.Core.StateMachines.PlayerBody;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;
using static Greed.Core.StateMachine;

namespace Greed.Unity
{
	public class PlayerBodyInstaller : MonoInstaller
	{
		[Inject] private IStats _stats;

		[Header("Picker")]
		[SerializeField] private Transform _pickupSlot;

		public override void InstallBindings()
		{
			var collectColliderTag = "CollectCollider";
			Container.BindInterfacesTo<CollectorHandler>().AsSingle()
				.WithArguments(collectColliderTag);

			Container.BindInterfacesTo<PickUpHandler>().AsSingle();

			Container.BindInterfacesTo<ThrowHandler>().AsSingle()
				.WithArguments(_stats.ThrowForce);

			InstallStateMachine();
		}

		private void InstallStateMachine()
		{
			Container.BindInterfacesAndSelfTo<InactiveState>().AsSingle();
			Container.BindInterfacesAndSelfTo<IdleState>().AsSingle();
			Container.BindInterfacesAndSelfTo<MoveState>().AsSingle();
			Container.BindInterfacesAndSelfTo<ThrowState>().AsSingle();

			var transitions = new Dictionary<Type, Transitions>
				{ //
					{ typeof(InactiveState), new Transitions { { "Activate", typeof(IdleState) } } },
					{ typeof(IdleState), new Transitions { { "StartMoving", typeof(MoveState) }, { "Throw", typeof(ThrowState) } } },
					{ typeof(MoveState), new Transitions { { "StopMoving", typeof(IdleState) }, { "Throw", typeof(ThrowState) } } },
					{ typeof(ThrowState), new Transitions { { "Done", typeof(InactiveState) } } },
				};
			Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle()
				.WithArguments(transitions);
		}
	}
}
