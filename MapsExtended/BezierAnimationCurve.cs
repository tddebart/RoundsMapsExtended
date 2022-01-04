using UnityEngine;

namespace MapsExt
{
	public class BezierAnimationCurve
	{
		private Vector2 c1;
		private Vector2 c2;

		public BezierAnimationCurve(float x1, float y1, float x2, float y2)
		{
			this.c1 = new Vector2(x1, y1);
			this.c2 = new Vector2(x2, y2);
		}

		public float Evaluate(float time)
		{
			float t = this.BinarySearchT(time, 0, 1);
			return this.CalcBezier(t).y;
		}

		private float BinarySearchT(float x, float min, float max)
		{
			float diff = 1;
			float currentT = 0;

			for (int i = 0; i < 10 && Mathf.Abs(diff) > 0.0001f; i++)
			{
				currentT = min + (max - min) / 2.0f;
				diff = this.CalcBezier(currentT).x - x;

				if (diff > 0)
				{
					max = currentT;
				}
				else
				{
					min = currentT;
				}
			}

			return currentT;
		}

		private Vector2 CalcBezier(float t) => t * (t * (t * (Vector2.one - 3 * this.c2 + 3 * this.c1) + (3 * this.c2 - 6 * this.c1)) + (3 * this.c1));
	}
}