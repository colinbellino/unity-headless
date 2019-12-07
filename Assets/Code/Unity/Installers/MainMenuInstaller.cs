using Greed.Core;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class MainMenuInstaller : MonoInstaller
	{
		[SerializeField] private GameObject _root;

		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<MenuView>().AsSingle()
				.WithArguments(Wrappers.Wrap(_root));
			// Container.BindInterfacesTo<MainMenuHandler>().AsSingle();
		}
	}
}
