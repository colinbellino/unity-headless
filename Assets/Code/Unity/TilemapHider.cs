using UnityEngine;
using UnityEngine.Tilemaps;

namespace Greed.Unity
{
	public class TilemapHider : MonoBehaviour
	{
		public void Start()
		{
			GetComponent<TilemapRenderer>().enabled = false;
		}
	}
}
