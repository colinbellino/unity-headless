using System;
using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class CameraRigFacade : MonoBehaviour
	{
		private ICameraRig _rig;

		[Inject]
		public void Construct(ICameraRig rig)
		{
			_rig = rig;
		}

		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.transform.root.CompareTag("Player"))
			{
				Enum.TryParse(collision.otherCollider.name, out Directions direction);
				_rig.MoveOnGrid(direction.ToVector());
			}
		}
	}
}
