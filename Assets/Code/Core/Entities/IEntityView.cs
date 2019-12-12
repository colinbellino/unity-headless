using Greed.UnityWrapper;
using UniRx.Async;
using UnityEngine;

namespace Greed.Core
{
	public interface IEntityView
	{
		Vector3 Position { get; }
		Vector3 LocalPosition { get; set; }
		ITransform Transform { get; }

		void MovePosition(Vector3 position);
		void Place(Vector3 position);
		void AttachTo(IEntity target);

		UniTask PlayAnimation(string stateName, int layer = -1, float normalizedTime = float.NegativeInfinity);
		void SetAnimationFloat(string stateName, float value);
	}
}
