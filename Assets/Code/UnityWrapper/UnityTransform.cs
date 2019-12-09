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

		public ITransform Parent
		{
			get => Wrappers.Wrap(_transform.parent);
			set => _transform.parent = value.Original;
		}

	}
}
