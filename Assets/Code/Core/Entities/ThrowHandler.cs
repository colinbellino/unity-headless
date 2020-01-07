using UniRx.Async;
using UnityEngine;

namespace Greed.Core
{
	public class ThrowHandler : IThrowHandler
	{
		private readonly IEntity _entity;
		private readonly int _throwForce;

		private const string _throwAnimationName = "Throw";

		public ThrowHandler(IEntity entity, int throwForce)
		{
			_entity = entity;
			_throwForce = throwForce;
		}

		public async UniTask Throw(IEntity entityToThrow, Vector3 direction)
		{
			entityToThrow.View.Detach();
			entityToThrow.View.Velocity = Vector2.zero;
			entityToThrow.View.AddForce(direction * _throwForce, ForceMode2D.Impulse);

			_entity.CurrentPickup = null;

			await _entity.View.PlayAnimationTask(_throwAnimationName);
		}
	}
}
