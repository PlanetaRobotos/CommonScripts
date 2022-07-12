using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff
{
    public class InstantiateProvider : IInstanteProvider
    {
        private readonly DiContainer _diContainer;

        private InstantiateProvider(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Instantiate<T>(string path) where T : Object
        {
            var template = Resources.Load<GameObject>(path);
            return DIInstantiate<T>(template, Vector3.zero, Quaternion.identity, null);
        }

        public T Instantiate<T>(string path, Vector3 at) where T : Object
        {
            var template = Resources.Load<GameObject>(path);
            return DIInstantiate<T>(template, at, Quaternion.identity, null);
        }

        public T Instantiate<T>(string path, Transform parent) where T : Object
        {
            var template = Resources.Load<GameObject>(path);
            return DIInstantiate<T>(template, Vector3.zero, Quaternion.identity, parent);
        }

        public T Instantiate<T>(T template) where T : Object
        {
            var prefab = DIInstantiate(template, Vector3.zero, Quaternion.identity, null);
            return prefab;
        }

        public T Instantiate<T>(T template, Transform parent) where T : Object
        {
            var prefab = DIInstantiate(template, Vector3.zero, Quaternion.identity, parent);
            return prefab;
        }

        public T Instantiate<T>(T template, Vector3 at) where T : Object
        {
            var prefab = DIInstantiate(template, at, Quaternion.identity, null);
            return prefab;
        }

        public T Instantiate<T>(GameObject template, Vector3 at, Vector3 scale) where T : Object
        {
            var prefab = DIInstantiate(template, at, Quaternion.identity, null);
            prefab.transform.localScale = scale;
            return (T)(Object)prefab;
        }

        public T Instantiate<T>(T template, Vector3 at, Transform parent) where T : Object
        {
            var prefab = DIInstantiate(template, at, Quaternion.identity, parent);
            return prefab;
        }

        public T Instantiate<T>(GameObject template, Vector3 at, Vector3 scale, Transform parent) where T : Object
        {
            var prefab = DIInstantiate(template, at, Quaternion.identity, parent);
            prefab.transform.localScale = scale;
            return (T)(Object)prefab;
        }

        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        private T DIInstantiate<T>(GameObject template, Vector3 at, Quaternion rot, Transform parent)
            where T : Object =>
            _diContainer.InstantiatePrefabForComponent<T>(template, at, rot, parent);

        private T DIInstantiate<T>(T template, Vector3 at, Quaternion rot, Transform parent) where T : Object =>
            _diContainer.InstantiatePrefabForComponent<T>(template, at, rot, parent);
    }
}