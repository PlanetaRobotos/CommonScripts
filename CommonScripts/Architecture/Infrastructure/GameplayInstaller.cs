using _Project.Scripts.Mechanics;
using _Project.Scripts.Mechanics.WormStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.Game;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private Worm _worm;
        
        public override void InstallBindings()
        {
            Container.Bind<Worm>().FromInstance(_worm).AsSingle();
            
            BindHeroController();
            BindLevels();
        }

        private void BindHeroController()
        {
            Container.Bind<HeroController>().AsSingle();
        }

        private void BindLevels()
        {
            // Container.Bind<Levels>().AsSingle();
        }
    }
}