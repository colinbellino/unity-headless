using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class OrbitAroundTarget : ITickable
	{
		private readonly IEntityView _view;
		private readonly ITime _time;
		private readonly float _attractionForce;
		private readonly float _rotationSpeed;

		private ITransform _target;
		private bool _active;

		public OrbitAroundTarget(
			IEntityView view,
			ITime time,
			float attractionForce,
			float rotationSpeed
		)
		{
			_view = view;
			_time = time;
			_attractionForce = attractionForce;
			_rotationSpeed = rotationSpeed;
		}

		public void Activate(ITransform target)
		{
			_target = target;

			_view.AttachTo(_target, false);
			_active = true;
		}

		public void Tick()
		{
			if (_active)
			{
				Orbit();
			}
		}

		private void Orbit()
		{
			var angle = _rotationSpeed * _time.DeltaTime;
			_view.RotateAround(_target.Position, Vector3.forward, angle);

			var step = _attractionForce * _time.DeltaTime;
			_view.MoveTowards(_target.Position, step);
		}
	}
}
