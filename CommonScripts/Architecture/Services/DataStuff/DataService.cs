using _Project.Scripts.Architecture.SettingsStuff;
using _Project.Scripts.Services;
using Assets._Project.Scripts.Utilities.Constants;

namespace _Project.Scripts.SettingsStuff
{
    public class DataService : IDataService
    {
        public WorldSettings WorldSettings { get; }
        public UISettings UISettings { get; }

        public DataService(IAssetService assetService)
        {
            WorldSettings = assetService.GetObjectByType<WorldSettings>(AssetPath.GlobalSettingsPath);
            UISettings = assetService.GetObjectByType<UISettings>(AssetPath.GlobalSettingsPath);
        }
    }
}