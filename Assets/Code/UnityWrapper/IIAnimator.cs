using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface IAnimator
	{
		void Play(string stateName, int layer, float normalizedTime);
		void SetFloat(string name, float value);
		void SetTrigger(string name);
		AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex);
	}
}
