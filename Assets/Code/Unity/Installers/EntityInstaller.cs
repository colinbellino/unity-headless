using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class EntityInstaller : MonoInstaller
	{
		[SerializeField] private EntityFacade _facade;
		[SerializeField] private Rigidbody2D _rigidbody;
		[SerializeField] private Transform _transform;
		[SerializeField] private Animator _animator;
		[SerializeField] private Collider2D _physicsCollider;
		[SerializeField] private int _moveSpeed;

		public override void InstallBindings()
		{
			Container.Bind<IEntity>().FromInstance(_facade);
			Container.Bind<EntityInputState>().AsSingle();

			Container.BindInterfacesAndSelfTo<EntityView>().AsSingle()
				.WithArguments(
					Wrappers.Wrap(_rigidbody),
					Wrappers.Wrap(_transform),
					Wrappers.Wrap(_animator),
					Wrappers.Wrap(_physicsCollider)
				);

			Container.BindInterfacesTo<EntityMoveHandler>().AsSingle()
				.WithArguments(_moveSpeed);
		}
	}
}
