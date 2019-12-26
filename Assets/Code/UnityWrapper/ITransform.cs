using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface ITransform
	{
		Vector3 Position { get; set; }
		Vector3 LocalPosition { get; set; }
		ITransform Parent { get; set; }
		Transform Original { get; }

		void RotateAround(Vector3 target, Vector3 axis, float angle);
	}
}
