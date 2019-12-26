using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class ShardInstaller : MonoInstaller
	{
		[Inject] private IStats _stats;

		[SerializeField] private Collider2D _collectCollider;

		public override void InstallBindings()
		{
			Container.BindInterfacesTo<OrbitOnCollect>().AsSingle()
				.WithArguments(Wrappers.Wrap(_collectCollider));

			var attractionForce = 1f;
			var rotationSpeed = 500f;
			Container.BindInterfacesAndSelfTo<OrbitAroundTarget>().AsSingle()
				.WithArguments(attractionForce, rotationSpeed);
		}
	}
}
