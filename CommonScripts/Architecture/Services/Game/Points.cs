using _Project.Scripts.Services.InputStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff;
using submodules.CommonScripts.CommonScripts.Utilities.Tools;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class Points : MonoBehaviour
    {
        private InputBehaviour _inputBehaviour;
        private IInstantiate _instantiateProvider;

        [Inject]
        private void Construct(InputBehaviour inputBehaviour, IInstantiate instantiateProvider)
        {
            _instantiateProvider = instantiateProvider;
            _inputBehaviour = inputBehaviour;
        }
        
        public void Initialize()
        {
            _inputBehaviour.ObjectMouseClick += ScreenMouseClick;
        }

        private void ScreenMouseClick(GameObject obj)
        {
            Debug.Log($"{obj}");
        }
    }
}