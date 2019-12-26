using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine;

namespace Greed.Core
{
	public interface IEntityView
	{
		Vector3 Position { get; }
		Vector3 LocalPosition { get; set; }
		Vector2 Velocity { get; set; }
		ITransform Transform { get; }
		ICollider2D PhysicsCollider { get; }

		void MovePosition(Vector3 position);
		void Place(Vector3 position);
		void AttachTo(ITransform target, bool resetLocalPosition = true);
		void Detach();

		void AddForce(Vector2 force, ForceMode2D mode = ForceMode2D.Force);
		void MoveTowards(Vector3 destination, float step);
		void RotateAround(Vector3 target, Vector3 axis, float angle);

		UniTask PlayAnimation(string stateName, int layer = 0, float normalizedTime = float.NegativeInfinity);
		void SetAnimationFloat(string name, float value);
		void SetAnimationTrigger(string name);
	}
}
