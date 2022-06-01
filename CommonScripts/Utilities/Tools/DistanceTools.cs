using System;
using UnityEngine;

namespace _Project.Scripts.Mechanics
{
    public static class DistanceTools
    {
        public static void CheckDistance(float minDistance, Vector2 posA, Vector2 posB, Action<Vector2> action)
        {
            int counter = 0;
            while (Vector2.Distance(posA, posB) < minDistance)
            {
                if (counter >= 50) return;

                action?.Invoke(Vector2.zero);
                counter++;
            }
        }
    }
}