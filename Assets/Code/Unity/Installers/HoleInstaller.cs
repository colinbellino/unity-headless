using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class HoleInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			var fallColliderTag = "PhysicsCollider";
			Container.BindInterfacesAndSelfTo<FallHandler>().AsSingle()
				.WithArguments(fallColliderTag);
		}
	}
}
