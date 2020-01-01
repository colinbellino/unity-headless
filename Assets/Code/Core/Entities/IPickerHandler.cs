using UniRx.Async;

namespace Greed.Core
{
	public interface IPickerHandler
	{
		UniTask PickUp(IEntity entityToPickUp);
	}
}
