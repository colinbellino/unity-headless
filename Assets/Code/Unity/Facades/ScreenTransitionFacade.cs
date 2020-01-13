using Greed.Core;
using UnityEngine;
using Zenject;

namespace Greed.Unity
{
	// public class ScreenTransitionFacade : MonoBehaviour
	// {
	// 	[SerializeField] private Directions _direction;

	// 	private readonly string _physicsColliderTag = "PhysicsCollider";

	// 	private ICameraRig _rig;

	// 	[Inject]
	// 	public void Construct(ICameraRig rig)
	// 	{
	// 		_rig = rig;
	// 	}

	// 	private void OnTriggerEnter2D(Collider2D collider)
	// 	{
	// 		if (collider.CompareTag("Player") && collider.CompareTag(_physicsColliderTag))
	// 		{
	// 			_rig.MoveInDirection(_direction.ToVector());
	// 		}
	// 	}
	// }
}
