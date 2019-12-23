using Greed.Core;
using UnityEngine;

namespace Greed.Unity
{
	[CreateAssetMenu(menuName = "Greed/Stats")]
	public class Stats : ScriptableObject, IStats
	{
		[SerializeField] private int _moveSpeed;
		[SerializeField] private int _throwSpeed;

		public int MoveSpeed
		{
			get => _moveSpeed;
			set => _moveSpeed = value;
		}

		public int ThrowForce
		{
			get => _throwSpeed;
			set => _throwSpeed = value;
		}
	}
}
