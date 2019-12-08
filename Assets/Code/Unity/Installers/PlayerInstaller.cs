using System;
using System.Collections.Generic;
using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PlayerInstaller : MonoInstaller
	{
		[SerializeField] private Rigidbody2D _rigidbody;
		[SerializeField] private Transform _transform;
		[SerializeField] private Animator _animator;
		[SerializeField] private int _moveSpeed;

		public override void InstallBindings()
		{
			Container.Bind<EntityInputState>().AsSingle();
			Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();

			Container.BindInterfacesAndSelfTo<EntityView>().AsSingle()
				.WithArguments(Wrappers.Wrap(_rigidbody), Wrappers.Wrap(_transform), Wrappers.Wrap(_animator));

			Container.BindInterfacesTo<EntityMoveHandler>().AsSingle()
				.WithArguments(_moveSpeed);

			Container.Bind<EntityPickUpHandler>().AsSingle();

			InstallStateMachine();

			Container.BindInterfacesTo<PlayerController>().AsSingle();
		}

		private void InstallStateMachine()
		{
			var idleTransitions = new Dictionary<string, Type> { { "PickUp", typeof(EntityEncumberedState) } };
			Container.BindInterfacesAndSelfTo<EntityIdleState>().AsSingle().WithArguments(idleTransitions);

			var encumberedTransitions = new Dictionary<string, Type> { { "Throw", typeof(EntityIdleState) } };
			Container.BindInterfacesAndSelfTo<EntityEncumberedState>().AsSingle().WithArguments(encumberedTransitions);

			Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle();
		}
	}
}
