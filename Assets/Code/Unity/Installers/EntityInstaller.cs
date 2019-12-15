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
		[SerializeField] private Transform _pickupSlot;

		[SerializeField] private int _moveSpeed;
		[SerializeField] private float _throwForce = 20f;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PickerHandler>().AsSingle()
				.WithArguments(Wrappers.Wrap(_pickupSlot), _throwForce);

			Container.BindInterfacesAndSelfTo<PickupHandler>().AsSingle();

			Container.BindInterfacesAndSelfTo<MoveHandler>().AsSingle()
				.WithArguments(_moveSpeed);

			Container.BindInterfacesAndSelfTo<EntityView>().AsSingle()
				.WithArguments(
					Wrappers.Wrap(_rigidbody),
					Wrappers.Wrap(_transform),
					Wrappers.Wrap(_animator),
					Wrappers.Wrap(_physicsCollider)
				);

			Container.Bind<IEntity>().FromInstance(_facade);
			Container.Bind<EntityInputState>().AsSingle();
		}
	}
}
