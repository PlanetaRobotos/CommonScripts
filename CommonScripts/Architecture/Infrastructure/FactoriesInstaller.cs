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

            Container.Bind<IWasherFactory>().To<WasherFactory>().AsSingle();
        }

        private void BindGameFiledFactory()
        {
            Container.Bind<GameFiledFactory>().AsSingle();
        }

        private void BindBallFactory()
        {
            Container.Bind<IBallFactory>().To<BallFactory>().AsSingle();
        }
    }
}