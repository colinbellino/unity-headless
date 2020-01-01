using System;
using System.Collections.Generic;
using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PlayerBodyInstaller : MonoInstaller
	{
		[Inject] private IStats _stats;

		[Header("Picker")]
		[SerializeField] private Transform _pickupSlot;

		public override void InstallBindings()
		{
			Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();

			var collectColliderTag = "CollectCollider";
			Container.BindInterfacesTo<CollectorHandler>().AsSingle()
				.WithArguments(collectColliderTag);

			Container.BindInterfacesAndSelfTo<PickerHandler>().AsSingle()
				.WithArguments(Wrappers.Wrap(_pickupSlot), _stats.ThrowForce);

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
