using UnityEngine;

namespace Greed.Core
{
	public interface IEntity
	{
		string Name { get; }
		IEntityView View { get; }
	}
}
