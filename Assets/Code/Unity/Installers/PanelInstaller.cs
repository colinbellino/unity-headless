using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class PanelInstaller : MonoInstaller
	{
		[SerializeField] private GameObject _root;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<PanelView>().AsSingle()
				.WithArguments(Wrappers.Wrap(_root));
		}
	}
}
