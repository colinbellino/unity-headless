using Greed.UnityWrapper;
using UnityEngine;

namespace Greed.Core
{
	public interface IEntity
	{
		void Place(Vector3 position);
		string Name { get; }
	}
}
