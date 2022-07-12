using System.Collections.Generic;
using submodules.CommonScripts.CommonScripts.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services
{
    public static class RandomUtils
    {
        public static Vector3 Get2AxisValues(MinMaxFloat xOffset, MinMaxFloat yOffset, MinMaxFloat zOffset)
        {
            float randX = GetValue(xOffset);
            float randY = GetValue(yOffset);
            float randZ = GetValue(zOffset);
            return new Vector3(randX, randY, randZ);
        }

        public static Vector3 Get3AxisValues(MinMaxFloat offset)
        {
            float randX = GetValue(offset);
            float randY = GetValue(offset);
            float randZ = GetValue(offset);
            return new Vector3(randX, randY, randZ);
        }
        
        public static Vector2 Get2AxisValues(MinMaxFloat xOffset, MinMaxFloat yOffset)
        {
            float randX = GetValue(xOffset);
            float randY = GetValue(yOffset);
            return new Vector2(randX, randY);
        }
        
        public static Vector2 Get2AxisValues(MinMaxFloat offset)
        {
            float randX = GetValue(offset);
            float randY = GetValue(offset);
            return new Vector2(randX, randY);
        }

        public static float GetValue(MinMaxFloat offset) =>
            Random.Range(offset.MinValue, offset.MaxValue);

        public static Vector2 GetValue(Borders borders) =>
            new Vector2(Random.Range(borders.XBorder.MinValue, borders.XBorder.MaxValue),
                Random.Range(borders.YBorder.MinValue, borders.YBorder.MaxValue));

        public static float GetValue(float min, float max)
        {
            MinMaxFloat offset = new MinMaxFloat(min, max);
            return Random.Range(offset.MinValue, offset.MaxValue);
        }

        public static int GetValue(MinMaxInt minMaxValue) =>
            Random.Range(minMaxValue.MinValue, minMaxValue.MaxValue);

        public static int GetValue(int min, int max) =>
            Random.Range(min, max);

        public static Vector3 GetRandomDirectionXZ()
        {
            return new Vector3(GetValue(-1f, 1f), 0f, GetValue(-1f, 1f)).normalized;
        }

        public static Vector3 GetRandomDirectionXY =>
            new Vector3(GetValue(-1f, 1f), GetValue(-1f, 1f), 0f).normalized;

        public static Vector2 GetRandomPointInsideCircle(float patrolRadius) =>
            Random.insideUnitCircle * patrolRadius;

        public static List<int> GetDifferentValues(int amount, MinMaxInt minMaxValue)
        {
            var randomList = new List<int>(amount);
            for (int i = 0; i < amount; i++)
            {
                int numToAdd = GetValue(minMaxValue);
                while (randomList.Contains(numToAdd))
                    numToAdd = GetValue(minMaxValue);
                randomList.Add(numToAdd);
            }

            return randomList;
        }

        public static Vector2 GetRandomScreenPoint(float bordersOffset)
        {
            var borders = Utilities.Tools.ScreenTools.GetScreenValuesAspect();
            return new Vector2(GetValue(-borders.HalfWidth + bordersOffset, borders.HalfWidth - bordersOffset),
                GetValue(-borders.HalfHeight + bordersOffset, borders.HalfHeight - bordersOffset));
        }
    }
}