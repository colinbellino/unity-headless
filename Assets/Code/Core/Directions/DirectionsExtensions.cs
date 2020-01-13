using System;
using UnityEngine;

namespace Greed.Core
{
	public static class DirectionsExtensions
	{
		public static Vector2Int ToVector(this Directions direction)
		{
			switch (direction)
			{
				case Directions.North:
					return new Vector2Int(0, 1);
				case Directions.East:
					return new Vector2Int(1, 0);
				case Directions.South:
					return new Vector2Int(0, -1);
				case Directions.West:
					return new Vector2Int(-1, 0);
				default:
					throw new ArgumentException("Invalid direction.");
			}
		}
	}
}
