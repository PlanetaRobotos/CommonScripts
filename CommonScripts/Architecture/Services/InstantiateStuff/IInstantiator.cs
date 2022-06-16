using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff
{
    public interface IInstantiator
    {
        T Instantiate<T>(string path) where T : Object;
        T Instantiate<T>(string path, Vector3 at) where T : Object;
        T Instantiate<T>(string path, Transform parent) where T : Object;
        T Instantiate<T>(T template) where T : Object;
        T Instantiate<T>(T template, Transform parent) where T : Object;
        T Instantiate<T>(T template, Vector3 at) where T : Object;
        T Instantiate<T>(GameObject template, Vector3 at, Vector3 scale) where T : Object;
        T Instantiate<T>(T template, Vector3 at, Transform parent) where T : Object;
        T Instantiate<T>(GameObject template, Vector3 at, Vector3 scale, Transform parent) where T : Object;

        T Load<T>(string path) where T : Object;
    }
}