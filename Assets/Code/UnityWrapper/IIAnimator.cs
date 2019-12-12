using UnityEngine;

namespace Greed.UnityWrapper
{
	public interface IAnimator
	{
		void Play(string stateName, int layer, float normalizedTime);
		void SetFloat(string stateName, float value);
		AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex);
	}
}
