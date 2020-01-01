using UnityEngine;

namespace Greed.UnityWrapper
{
	public static class Wrappers
	{
		public static IGameObject Wrap(GameObject gameObject)
		{
			if (gameObject == null)
			{
				Debug.LogWarning("Didn't wrap GameObject because it was null.");
				return null;
			}

			return new UnityGameObject(gameObject);
		}

		public static IRigidbody2D Wrap(Rigidbody2D rigidbody)
		{
			if (rigidbody == null)
			{
				Debug.LogWarning("Didn't wrap Rigidbody2D because it was null.");
				return null;
			}

			return new UnityRigidbody2D(rigidbody);
		}

		public static ITransform Wrap(Transform transform)
		{
			if (transform == null)
			{
				Debug.LogWarning("Didn't wrap Transform because it was null.");
				return null;
			}

			return new UnityTransform(transform);
		}

		public static IAnimator Wrap(Animator animator)
		{
			if (animator == null)
			{
				Debug.LogWarning("Didn't wrap Animator because it was null.");
				return null;
			}

			return new UnityAnimator(animator);
		}

		public static ICollider2D Wrap(Collider2D collider)
		{
			if (collider == null)
			{
				Debug.LogWarning("Didn't wrap Collider2D because it was null.");
				return null;
			}

			return new UnityCollider2D(collider);
		}

		public static IRaycastHit2D Wrap(RaycastHit2D hit)
		{
			return new UnityRaycastHit2D(hit);
		}
	}
}
