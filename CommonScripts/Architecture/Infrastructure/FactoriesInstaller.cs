using Zenject;

namespace _Project.Scripts.Infrastructure
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBallFactory();
        }

        private void BindBallFactory()
        {
            Container.Bind<IBallFactory>().To<BallFactory>().AsSingle();
        }
    }
}