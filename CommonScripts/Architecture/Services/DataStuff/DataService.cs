using submodules.CommonScripts.CommonScripts.Architecture.Services.AssetsStuff;
using submodules.CommonScripts.CommonScripts.SettingsStuff.Global;
using submodules.CommonScripts.CommonScripts.Utilities.Constants;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.DataStuff
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