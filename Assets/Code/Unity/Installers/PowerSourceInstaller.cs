using Greed.Core;
using Zenject;

namespace Greed.Unity
{
	public class PowerSourceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<IPowerSource>().To<PowerSource>().FromComponentOnRoot();
		}
	}
}
