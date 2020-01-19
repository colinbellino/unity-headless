using System;
using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	public class CameraRigFacade : MonoBehaviour
	{
		private ICameraRig _rig;
		private float _timestamp;

		private readonly float _cooldown = 0.1f;

		[Inject]
		public void Construct(ICameraRig rig)
		{
			_rig = rig;
		}

		public void OnCollisionEnter2D(Collision2D collision)
		{
			if (Time.time > _timestamp)
			{
				if (collision.transform.root.CompareTag("Player"))
				{
					Enum.TryParse(collision.otherCollider.name, out Directions direction);
					_rig.MoveOnGrid(direction.ToVector());
					_timestamp = Time.time + _cooldown;
				}
			}
		}
	}
}
