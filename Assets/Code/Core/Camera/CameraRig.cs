using System.Collections;
using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class CameraRig : ICameraRig, IInitializable
	{
		private readonly Transform _rig;
		private readonly float _speed = 10f;
		private readonly AsyncProcessor _asyncProcessor;
		private readonly Vector2Int _screenSize = new Vector2Int(16, 9);

		private IEnumerator _moveEnumerator;
		private Vector2Int _position;

		public static Vector3 GridToWorldSpace(Vector2 value) => new Vector3(value.x, value.y, 0f);

		public CameraRig(Transform rig, AsyncProcessor asyncProcessor)
		{
			_rig = rig;
			_asyncProcessor = asyncProcessor;
		}

		public void Initialize()
		{
			_position = new Vector2Int((int)_rig.position.x, (int)_rig.position.y);
		}

		public void MoveOnGrid(Vector2Int direction)
		{
			if (_moveEnumerator != null)
			{
				_asyncProcessor.StopCoroutine(_moveEnumerator);
			}

			_position += direction * _screenSize;
			_moveEnumerator = LerpCameraTo(GridToWorldSpace(_position));
			_asyncProcessor.StartCoroutine(_moveEnumerator);
		}

		private IEnumerator LerpCameraTo(Vector3 destination)
		{
			while (Vector3.Distance(_rig.transform.localPosition, destination) > 0.01f)
			{
				_rig.transform.localPosition = Vector3.Lerp(_rig.transform.localPosition, destination, Time.deltaTime * _speed);
				yield return null;
			}
		}
	}
}
