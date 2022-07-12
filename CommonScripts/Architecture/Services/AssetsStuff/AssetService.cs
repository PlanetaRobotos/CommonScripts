using System.Linq;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using submodules.CommonScripts.CommonScripts.Constants;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.AssetsStuff
{
    public interface IAssetService
    {
        GameObject LoadObjectByName(string path);
        T LoadObjectByName<T>(string path) where T : Object;
        T LoadObjectByType<T>(string path) where T : Object;
        GameObject[] LoadObjectsByType(string path);
        GameObject LoadObjectByIndex(string path, string body, int index);
        T LoadScriptableObjectByIndex<T>(string path, string body, int index) where T : ScriptableObject;
        T Load<T>(string path) where T : ScriptableObject;
        WindowBase LoadWindow(WindowType windowType);
    }

    public class AssetService : IAssetService
    {
        private readonly DiContainer _diContainer;

        public AssetService(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public GameObject LoadObjectByName(string path) =>
            Resources.Load<GameObject>(path);

        public T LoadObjectByName<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public T LoadObjectByType<T>(string path) where T : Object
        {
            Object[] objects = Resources.LoadAll<Object>(path);
            return (T)objects.FirstOrDefault(o => o.GetType() == typeof(T));
        }

        public GameObject[] LoadObjectsByType(string path)
        {
            GameObject[] objects = Resources.LoadAll<GameObject>(path);
            return objects;
        }

        public GameObject LoadObjectByIndex(string path, string body, int index)
        {
            string pathFull = $"{path}/{body}_{index.ToString()}";
            var obj = Resources.Load<GameObject>(pathFull);
            return obj;
        }

        public T LoadScriptableObjectByIndex<T>(string path, string body, int index) where T : ScriptableObject
        {
            string pathFull = $"{path}/{body}_{index.ToString()}";
            return Resources.Load<T>(pathFull);
        }

        public T Load<T>(string path) where T : ScriptableObject
        {
            return Resources.Load<T>(path);
        }

        public WindowBase LoadWindow(WindowType windowType)
        {
            WindowBase[] windows = Resources.LoadAll<WindowBase>(AssetPath.WindowsPath);
            return windows.First(window => window.GetWindowType() == windowType);
        }
    }

    public class ResourcesKey
    {
        public string Key { get; }
        private ResourcesKey(string key) => Key = key;
        public static implicit operator ResourcesKey(string key) => new ResourcesKey(key);
    }
}