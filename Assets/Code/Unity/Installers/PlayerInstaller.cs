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
		[SerializeField] private int _moveSpeed;

		public override void InstallBindings()
		{
			Container.Bind<EntityInputState>().AsSingle();
			Container.BindInterfacesAndSelfTo<EntityView>().AsSingle()
				.WithArguments(Wrappers.Wrap(_rigidbody), Wrappers.Wrap(_transform));
			Container.BindInterfacesTo<EntityMoveHandler>().AsSingle()
				.WithArguments(_moveSpeed);
			Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
		}
	}
}
