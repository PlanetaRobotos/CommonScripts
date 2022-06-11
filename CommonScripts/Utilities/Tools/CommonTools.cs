using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DG.Tweening;
using submodules.CommonScripts.CommonScripts.Architecture.Managers.StaticSave;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace submodules.CommonScripts.CommonScripts.Utilities.Tools
{
    public static class CommonTools
    {
        public static void SaveCurrentTime() =>
            SaveManager.SetString(SaveKey.LastQuitGameTime, DateTime.Now.ToString(CultureInfo.InvariantCulture));

        public static DateTime GetLastQuitGameTime =>
            DateTime.Parse(SaveManager.GetString(SaveKey.LastQuitGameTime));

        public static double GetQuitedGameSeconds() =>
            (DateTime.Now - GetLastQuitGameTime).TotalSeconds;

        public static int BoolToInt(bool val) => val ? 1 : 0;

        public static bool IntToBool(int val) => val != 0;

        public static int GetRandomIndex(int maxValue) => UnityEngine.Random.Range(0, maxValue);

        public static int[] GetRandomIndexes(int maxValue, int amount)
        {
            var rand = new System.Random();
            List<int> listNumbers = new List<int>();
            listNumbers.AddRange(Enumerable.Range(0, maxValue)
                .OrderBy(i => rand.Next()).Take(amount));
            return listNumbers.ToArray();
        }

        public static bool IsOnlyOneTouch()
        {
#if UNITY_EDITOR
            return true;
#else
        return Input.touchCount == 1;
#endif
        }

        public static void RestartScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public static void CountdownInt(TMP_Text textTMP, int timerStart, int timerEnd, float duration) =>
            DOVirtual.Float(timerStart, timerEnd, duration, value => textTMP.text = ((int) value).ToString());

        // public static T[] GetAllEnumElements<T>(Type enumType)
        // {
        //     return Enum.GetValues()
        // }
        public static void TimerActionLooped(ref float currentValue, float maxValue, Action action)
        {
            if (currentValue >= maxValue)
            {
                action?.Invoke();
                currentValue = 0f;
            }

            currentValue += Time.fixedDeltaTime;
        }

        public static void TimerActionOnce(ref float currentValue, float maxValue, Action action)
        {
            if (currentValue >= maxValue) 
                action?.Invoke();
            else 
                currentValue += Time.fixedDeltaTime;
        }
    }

    public static class RandomTools
    {
    
    }
}