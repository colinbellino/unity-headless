using UnityEngine;

namespace Greed.UnityWrapper
{
	public class UnityAnimator : IAnimator
	{
		private readonly Animator _animator;

		public UnityAnimator(Animator animator)
		{
			_animator = animator;
		}

		public void Play(string stateName, int layer, float normalizedTime)
		{
			_animator.Play(stateName, layer, normalizedTime);
		}

		public void SetFloat(string stateName, float value)
		{
			_animator.SetFloat(stateName, value);
		}
	}
}
