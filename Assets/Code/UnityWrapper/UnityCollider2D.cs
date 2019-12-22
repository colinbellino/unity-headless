using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityCollider2D : ICollider2D
	{
		private readonly Collider2D _collider;
		private readonly IGameObject _gameObject;

		public bool Enabled
		{
			get => _collider.enabled;
			set => _collider.enabled = value;
		}

		public bool IsTrigger => _collider.isTrigger;
		public IGameObject GameObject => _gameObject;

		public UnityCollider2D(Collider2D collider)
		{
			_collider = collider;
			_gameObject = Wrappers.Wrap(_collider.gameObject);
		}

		public Vector2 ClosestPoint(Vector2 position)
		{
			return _collider.ClosestPoint(position);
		}

		public bool Equals(ICollider2D other)
		{
			return GetHashCode() == other.GetHashCode();
		}

		public override int GetHashCode()
		{
			return _collider.GetHashCode();
		}
	}
}
