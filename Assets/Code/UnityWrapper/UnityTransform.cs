using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityTransform : ITransform
	{
		private readonly Transform _transform;

		public Transform Original => _transform;

		public UnityTransform(Transform transform)
		{
			_transform = transform;
		}

		public Vector3 Position
		{
			get => _transform.position;
			set => _transform.position = value;
		}

		public Vector3 LocalPosition
		{
			get => _transform.localPosition;
			set => _transform.localPosition = value;
		}

		public ITransform Parent
		{
			get => Wrappers.Wrap(_transform.parent);
			set => _transform.parent = value?.Original;
		}

		public void RotateAround(Vector3 target, Vector3 axis, float angle)
		{
			_transform.RotateAround(target, axis, angle);
		}
	}
}
