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

		public void SetFloat(string name, float value)
		{
			_animator.SetFloat(name, value);
		}

		public void SetTrigger(string name)
		{
			_animator.SetTrigger(name);
		}

		public AnimatorStateInfo GetCurrentAnimatorStateInfo(int layer)
		{
			return _animator.GetCurrentAnimatorStateInfo(layer);
		}
	}
}
