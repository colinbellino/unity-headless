using UnityEngine;

namespace Greed.Core
{
	public interface IEntityView
	{
		Vector3 Position { get; }
		void MovePosition(Vector3 position);
		void Place(Vector3 position);
	}
}
