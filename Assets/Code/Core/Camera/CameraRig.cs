using System;
using System.Collections;
using UnityEngine;

public class CameraRig
{
	// private readonly Transform _transitionsContainer;
	private readonly Transform _rig;
	private readonly float _speed = 10f;
	private readonly AsyncProcessor _asyncProcessor;

	public CameraRig(Transform rig, AsyncProcessor asyncProcessor)
	{
		_rig = rig;
		_asyncProcessor = asyncProcessor;
	}

	public static Vector3 GridToWorldSpace(Vector2 value) => new Vector3(value.x, value.y, 0f);

	public Action OnCameraMoveStart = delegate { };
	public Action OnCameraMoveEnd = delegate { };

	private IEnumerator _transition;
	private Vector2Int _gridPosition;

	public void MoveCameraInDirection(Vector2Int direction)
	{
		if (_transition != null)
		{
			_asyncProcessor.StopCoroutine(_transition);
		}

		_transition = MoveInDirection(direction);
		_asyncProcessor.StartCoroutine(_transition);
	}

	private IEnumerator MoveInDirection(Vector2Int direction)
	{
		_gridPosition += direction;

		// _transitionsContainer.localPosition = GridToWorldSpace(_gridPosition);
		OnCameraMoveStart();

		yield return LerpCameraTo(GridToWorldSpace(_gridPosition));

		OnCameraMoveEnd();
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

public class AsyncProcessor : MonoBehaviour
{
	// Purposely left empty
}
