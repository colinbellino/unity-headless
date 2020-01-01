using UniRx.Async;

namespace Greed.Core
{
	public interface IPickUpHandler
	{
		UniTask PickUp(IEntity entityToPickUp);
	}
}
