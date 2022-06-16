using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff
{
    public class InstantiateProvider : IInstantiator
    {
        public T Instantiate<T>(string path) where T : Object
        {
            var template = Resources.Load<GameObject>(path);
            var prefab = Object.Instantiate(template);
            return (T)(Object)prefab;
        }

        public T Instantiate<T>(string path, Vector3 at) where T : Object
        {
            var template = Resources.Load<GameObject>(path);
            var prefab = Object.Instantiate(template, at, Quaternion.identity);
            return (T)(Object)prefab;
        }

        public T Instantiate<T>(string path, Transform parent) where T : Object
        {
            var template = Resources.Load<GameObject>(path);
            var prefab = Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            return (T)(Object)prefab;
        }

        public T Instantiate<T>(T template) where T : Object
        {
            var prefab = Object.Instantiate(template);
            return prefab;
        }

        public T Instantiate<T>(T template, Transform parent) where T : Object
        {
            var prefab = Object.Instantiate(template, Vector3.zero, Quaternion.identity, parent);
            return prefab;
        }

        public T Instantiate<T>(T template, Vector3 at) where T : Object
        {
            var prefab = Object.Instantiate(template, at, Quaternion.identity);
            return prefab;
        }

        public T Instantiate<T>(GameObject template, Vector3 at, Vector3 scale) where T : Object
        {
            var prefab = Object.Instantiate(template, at, Quaternion.identity);
            prefab.transform.localScale = scale;
            return (T)(Object)prefab;
        }

        public T Instantiate<T>(T template, Vector3 at, Transform parent) where T : Object
        {
            var prefab = Object.Instantiate(template, at, Quaternion.identity, parent);
            return prefab;
        }

        public T Instantiate<T>(GameObject template, Vector3 at, Vector3 scale, Transform parent) where T : Object
        {
            var prefab = Object.Instantiate(template, at, Quaternion.identity, parent);
            prefab.transform.localScale = scale;
            return (T)(Object)prefab;
        }

        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}