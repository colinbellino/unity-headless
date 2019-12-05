using UnityEngine;

namespace Greed.UnityWrapper
{
	class UnityTransform : ITransform
	{
		private readonly Transform _transform;

		public UnityTransform(Transform transform)
		{
			_transform = transform;
		}

		public Vector3 Position
		{
			get => _transform.position;
			set => _transform.position = value;
		}
	}
}
