using UnityEngine;

namespace Greed.UnityWrapper
{
	public static class Wrappers
	{
		public static IGameObject Wrap(GameObject gameObject)
		{
			return new UnityGameObject(gameObject);
		}

		public static IRigidbody2D Wrap(Rigidbody2D rigidbody)
		{
			return new UnityRigidbody2D(rigidbody);
		}

		public static ITransform Wrap(Transform transform)
		{
			return new UnityTransform(transform);
		}

		public static IAnimator Wrap(Animator animator)
		{
			return new UnityAnimator(animator);
		}

		public static ICollider2D Wrap(Collider2D collider)
		{
			return new UnityCollider2D(collider);
		}

		public static IRaycastHit2D Wrap(RaycastHit2D hit)
		{
			return new UnityRaycastHit2D(hit);
		}
	}
}
