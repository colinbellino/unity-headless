using Zenject;

namespace Greed.Unity
{
	public class PowerSourceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PowerSource>().FromComponentOnRoot();
		}
	}
}
