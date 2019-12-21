using UnityEngine;

namespace Greed.Core
{
	public class AudioPlayer
	{
		private readonly AudioSource _audioSource;

		public AudioPlayer(AudioSource audioSource)
		{
			_audioSource = audioSource;
		}

		public void PlayOneShot(AudioClip clip)
		{
			_audioSource.PlayOneShot(clip);
		}
	}
}
