using _Project.Scripts.Services.InputStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff;
using submodules.CommonScripts.CommonScripts.Utilities.Tools;
using UnityEngine;
using Zenject;
using IInstantiator = submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff.IInstantiator;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class Points : MonoBehaviour
    {
        private InputBehaviour _inputBehaviour;
        private IInstantiator instantiatorProvider;

        [Inject]
        private void Construct(InputBehaviour inputBehaviour, IInstantiator instantiatorProvider)
        {
            this.instantiatorProvider = instantiatorProvider;
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