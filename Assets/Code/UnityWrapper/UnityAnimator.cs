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
	}
}
