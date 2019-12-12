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

		void MovePosition(Vector3 position);
		void Place(Vector3 position);
		void AttachTo(ITransform target);
		void Detach();

		void AddForce(Vector2 force, ForceMode2D mode = ForceMode2D.Force);

		UniTask PlayAnimation(string stateName, int layer = 0, float normalizedTime = float.NegativeInfinity);
		void SetAnimationFloat(string name, float value);
		void SetAnimationTrigger(string name);
	}
}
