using Greed.UnityWrapper;
using UnityEngine;
using Zenject;

namespace Greed.Core
{
	public class OrbitAroundTarget : IInitializable, ITickable
	{
		private readonly IEntityView _view;
		private readonly IEntity _target;
		private readonly ITime _time;
		private readonly float _attractionForce;
		private readonly float _rotationSpeed;

		private bool _active;

		public OrbitAroundTarget(
			IEntityView view,
			IEntity target,
			ITime time,
			float attractionForce,
			float rotationSpeed
		)
		{
			_view = view;
			_target = target;
			_time = time;
			_attractionForce = attractionForce;
			_rotationSpeed = rotationSpeed;
		}

		public void Initialize()
		{
			// _entity.TriggerEntered += TriggerEntered;
		}

		public void Dispose()
		{
			// _entity.TriggerEntered -= TriggerEntered;
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
			_view.RotateAround(_target.View.Position, Vector3.forward, angle);

			var step = _attractionForce * _time.DeltaTime;
			_view.MoveTowards(_target.View.Position, step);
		}

		private void Activate()
		{
			_view.AttachTo(_target.View.Transform);
			_view.LocalPosition = Vector2.up * 2f;
			_active = true;
		}
	}
}
