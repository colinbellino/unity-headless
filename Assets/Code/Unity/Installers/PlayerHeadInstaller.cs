using System;
using System.Collections.Generic;
using Greed.Core;
using Greed.Core.StateMachines.PlayerHead;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;
using static Greed.Core.StateMachine;

namespace Greed.Unity
{
	public class PlayerHeadInstaller : MonoInstaller
	{
		[SerializeField] private AssetReference _impactEffect;
		[SerializeField] private AudioClip _impactClip;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<ImpactHandler>().AsSingle()
				.WithArguments(_impactEffect, _impactClip);

			var impactColliderTag = "ImpactCollider";
			Container.BindInterfacesAndSelfTo<PickupImpact>().AsSingle()
				.WithArguments(impactColliderTag);

			InstallStateMachine();
		}

		private void InstallStateMachine()
		{
			Container.BindInterfacesAndSelfTo<IdleState>().AsSingle();
			Container.BindInterfacesAndSelfTo<MoveState>().AsSingle();
			Container.BindInterfacesAndSelfTo<RecalledState>().AsSingle();
			Container.BindInterfacesAndSelfTo<InactiveState>().AsSingle();

			var transitions = new Dictionary<Type, Transitions>
				{ //
					{ typeof(IdleState), new Transitions { { "StartMoving", typeof(MoveState) }, { "Recall", typeof(RecalledState) } } },
					{ typeof(MoveState), new Transitions { { "StopMoving", typeof(IdleState) }, { "Recall", typeof(RecalledState) } } },
					{ typeof(RecalledState), new Transitions { { "Done", typeof(InactiveState) } } },
					{ typeof(InactiveState), new Transitions { { "Throw", typeof(IdleState) } } },
				};
			Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle()
				.WithArguments(transitions);
		}
	}
}
