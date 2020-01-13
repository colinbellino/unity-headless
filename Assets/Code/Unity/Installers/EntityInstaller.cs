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
		[SerializeField] private AudioSource _audioSource;
		[SerializeField] private Collider2D _physicsCollider;

		[Header("Stats")]
		[SerializeField] private Stats _stats;

		[Header("Picker")]
		[SerializeField] private Transform _pickupSlot;

		public override void InstallBindings()
		{
			Container.Bind<IStats>().FromInstance(_stats);

			Container.Bind<AudioPlayer>().AsSingle()
				.WithArguments(_audioSource);

			Container.BindInterfacesAndSelfTo<MoveHandler>().AsSingle()
				.WithArguments(_stats.MoveSpeed);

			Container.BindInterfacesAndSelfTo<EntityView>().AsSingle()
				.WithArguments(
					Wrappers.Wrap(_rigidbody),
					Wrappers.Wrap(_transform),
					Wrappers.Wrap(_animator),
					Wrappers.Wrap(_physicsCollider)
				);

			Container.Bind<ITransform>().FromInstance(Wrappers.Wrap(_pickupSlot)).WhenInjectedInto<EntityFacade>();
			Container.Bind<IEntity>().To<EntityFacade>().FromInstance(_facade);
		}
	}
}
