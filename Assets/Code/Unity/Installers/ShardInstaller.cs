using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class ShardInstaller : MonoInstaller
	{
		[Inject] private IStats _stats;

		public override void InstallBindings()
		{
			// FIXME: Do something cleaner than this to find the target. Maybe a TargetFinder class ?
			var target = GameObject.Find("Player").GetComponent<IEntity>();

			// Container.BindInterfacesTo<MoveTowardsTarget>().AsSingle()
			// 	.WithArguments(target, _stats.MoveSpeed);
			var attractionForce = 1f;
			var rotationSpeed = 500f;
			Container.BindInterfacesTo<OrbitAroundTarget>().AsSingle()
				.WithArguments(target, attractionForce, rotationSpeed);
		}
	}
}
