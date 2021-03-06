using submodules.CommonScripts.CommonScripts.Architecture.Services.AssetsStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.DataStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.GizmosStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.Pool;
using submodules.CommonScripts.CommonScripts.Architecture.Services.SaveLoad;
using submodules.CommonScripts.CommonScripts.Architecture.Services.SaveLoad.IO;
using submodules.CommonScripts.CommonScripts.Architecture.Services.SceneStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.StateManagerStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Infrastructure
{
    public class ServicesInstaller : MonoInstaller
    {
        [SerializeField] private GizmosService _gizmosService;

        public override void InstallBindings()
        {
            BindTupleSateManager();
            BindSaveLoadService();
            BindPoolService();
            BindAssetService();
            BindDataService();
            BindUIService();
            BindGizmosService();
            BindInitializeProvider();
            BindSceneService();
        }

        private void BindTupleSateManager()
        {
            Container.Bind<IStateManager>().To<TupleStateManager>().AsSingle();
        }

        private void BindGizmosService()
        {
            Container.Bind<GizmosService>().FromInstance(_gizmosService).AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container.Bind<IWriterReader>().To<JsonWriterReader>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        }

        private void BindUIService()
        {
            Container.Bind<IUIService>().To<UIService>().AsSingle();
        }

        private void BindAssetService()
        {
            Container.Bind<IAssetService>().To<AssetService>().AsSingle();
        }

        private void BindDataService()
        {
            Container.Bind<IDataService>().To<DataService>().AsSingle();
        }

        private void BindPoolService()
        {
            Container.Bind<IPoolService>().To<PoolService>().AsSingle();
        }

        private void BindInitializeProvider()
        {
            Container.Bind<IInstantiateProvider>().To<InstantiateProvider>().AsSingle();
        }

        private void BindSceneService()
        {
            Container.Bind<ISceneService>().To<SceneService>().AsSingle();
        }
    }
}