using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityCollider2D : ICollider2D
	{
		private readonly Collider2D _collider;

		public bool Enabled
		{
			get => _collider.enabled;
			set => _collider.enabled = value;
		}

		public UnityCollider2D(Collider2D collider)
		{
			_collider = collider;
		}
	}
}
