using System;
using System.Collections.Generic;
using System.Linq;
using submodules.CommonScripts.CommonScripts.Utilities.Extensions;
using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Utilities.Tools
{
    public static class EnumTools
    {
        public static int GetLength(Type type) => Enum.GetValues(type).Length;
        public static T GetRandom<T>(Type type) => ((T[]) Enum.GetValues(type)).GetRandomElement();
        
        public static GameObject GetObjectByEnumName(Type enumType, string enumElement, Func<GameObject> func)
        {
            if (Enum.GetNames(enumType).Any(name => name == enumElement))
                return func?.Invoke();

            throw new ArgumentOutOfRangeException(nameof(enumElement), enumElement, "Resource is out of range");
        }

        public static void EnumNamesLoopAction(Type enumType, Action<string> action)
        {
            foreach (var name in Enum.GetNames(enumType))
                action.Invoke(name);
        }

        public static void DictionaryLoopAction(Dictionary<string, GameObject> dictionary, Action<string> action)
        {
            foreach (var name in dictionary.Keys)
                action.Invoke(name);
        }
    }
}