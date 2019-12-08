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

			Container.BindInterfacesTo<PlayerController>().AsSingle();
		}
	}
}
