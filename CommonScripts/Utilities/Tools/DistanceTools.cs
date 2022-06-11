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

            static Vector2 GetPoint() => RandomUtils.GetRandomScreenPoint(150);
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
    }
}