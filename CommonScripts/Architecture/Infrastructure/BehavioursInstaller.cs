using _Project.Scripts.Mechanics;
using _Project.Scripts.Services.InputStuff;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Infrastructure
{
    public class BehavioursInstaller : MonoInstaller
    {
        [SerializeField] private InputBehaviour _inputBehaviour;
        [SerializeField] private Control _control;

        public override void InstallBindings()
        {
            Container.Bind<Control>().FromInstance(_control).AsSingle();
        }
    }
}