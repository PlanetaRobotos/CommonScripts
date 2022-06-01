using _Project.Scripts.Architecture.SettingsStuff;

namespace _Project.Scripts.SettingsStuff
{
    public interface IDataService
    {
        WorldSettings WorldSettings { get; }
        UISettings UISettings { get; }
    }
}