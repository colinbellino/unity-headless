using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface ITransform
	{
		Vector3 Position { get; set; }
		ITransform Parent { get; set; }
		Transform Original { get; }
	}
}
