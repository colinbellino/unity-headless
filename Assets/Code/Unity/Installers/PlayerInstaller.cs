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

		public override void InstallBindings()
		{
			Container.Bind<EntityInputState>().AsSingle();
			Container.BindInterfacesAndSelfTo<EntityView>().AsSingle()
				.WithArguments(Wrappers.Wrap(_rigidbody), Wrappers.Wrap(_transform));
			Container.BindInterfacesTo<EntityMoveHandler>().AsSingle();
			Container.BindInterfacesTo<PlayerInputHandler>().AsSingle();
		}
	}
}
