using _Project.Scripts.FactoriesStuff;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Infrastructure
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameFiledFactory();
            BindBallFactory();
            BindWasherFactory();
        }

        private void BindGameFiledFactory()
        {
            Container.Bind<GameFiledFactory>().AsSingle();
        }

        private void BindWasherFactory()
        {
            Container.Bind<IWasherFactory>().To<WasherFactory>().AsSingle();
        }

        private void BindBallFactory()
        {
            Container.Bind<IBallFactory>().To<BallFactory>().AsSingle();
        }
    }
}