using System.Linq;
using submodules.CommonScripts.CommonScripts.Architecture.Services;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Utilities.Tools
{
    public static class DistanceTools
    {
        public static Vector2[] GetPoints(float minDistance, int amount)
        {
            var points = new Vector2[amount];
            points[0] = GetPoint();

            var nextPoint = GetPoint();

            for (int i = 1; i < amount; i++)
            {
                int counter = 0;
                while (IsBelowAny(minDistance, points, i, nextPoint))
                {
                    if (counter >= 50) break;

                    counter++;
                    nextPoint = GetPoint();
                }

                points[i] = nextPoint;
            }

            return points;
        }

        public static Vector2[] GetPoints(float minDistance, int amount, Collider2D collider)
        {
            var points = new Vector2[amount];
            points[0] = GetPoint(collider);

            var nextPoint = GetPoint(collider);

            for (int i = 1; i < amount; i++)
            {
                int counter = 0;
                while (IsBelowAny(minDistance, points, i, nextPoint))
                {
                    if (counter >= 50) break;

                    counter++;
                    nextPoint = GetPoint(collider);
                }

                points[i] = nextPoint;
            }

            return points;
        }

        private static bool IsBelowAny(float minDistance, Vector2[] points, int i, Vector2 nextPoint)
        {
            for (int j = 0; j < i; j++)
            {
                if (IsBelow(minDistance, points[j], nextPoint))
                    return true;
            }

            return false;
        }


        public static bool IsAbove(float minDistance, Vector2 posA, Vector2 posB) =>
            GetDistance(posA, posB) > minDistance;

        public static bool IsBelow(float minDistance, Vector2 posA, Vector2 posB) =>
            GetDistance(posA, posB) < minDistance;

        public static float GetDistance(Vector2 posA, Vector2 posB) => Vector2.Distance(posA, posB);

        public static Vector2 GetPoint()
        {
            var point = RandomUtils.GetRandomScreenPoint(150);
            return point;
        }

        public static Vector2 GetPoint(Collider2D collider)
        {
            var point = RandomUtils.GetRandomScreenPoint(150);

            int counter = 0;
            while (!IsInside(collider, point))
            {
                if (counter >= 50) break;

                counter++;
                point = GetPoint();
            }

            return point;
        }

        public static bool IsInside(Collider2D c, Vector3 point) => 
            c.bounds.Contains(point);
    }
}