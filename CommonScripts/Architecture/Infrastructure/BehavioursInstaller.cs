using _Project.Scripts.Services.InputStuff;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Infrastructure
{
    public class BehavioursInstaller : MonoInstaller
    {
        [SerializeField] private InputBehaviour _inputBehaviour;
        
        public override void InstallBindings()
        {
            Container.Bind<InputBehaviour>().FromInstance(_inputBehaviour).AsSingle();
        }
    }
}