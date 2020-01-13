using UniRx.Async;
using UnityEngine;

namespace Greed.Core
{
	public interface IThrowHandler
	{
		UniTask Throw(IEntity entityToThrow, Vector3 force);
	}
}
