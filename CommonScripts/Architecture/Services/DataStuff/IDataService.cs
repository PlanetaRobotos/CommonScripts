using submodules.CommonScripts.CommonScripts.SettingsStuff.Global;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.DataStuff
{
    public interface IDataService
    {
        WorldSettings WorldSettings { get; }
        UISettings UISettings { get; }
    }
}