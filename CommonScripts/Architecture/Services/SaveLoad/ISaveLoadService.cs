using System;
using submodules.CommonScripts.CommonScripts.Architecture.Services.SaveLoad.Data;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        Action OnDataUpdated { get; set; }
        PlayerData PlayerData { get; }
        GameConfig GameConfig { get; }
        bool IsSaveFileExist(string path);
        void SaveAllData();
        void LoadAllData();
        
        // T LoadData<T>();
        // void SaveData<T>();

        /// <summary>
        /// Uses for data transferring between  scenes (Main menu -> gameplay, e.t.c.)
        /// </summary>
        /// <param name="data"></param>
        // void SetCurrentSceneData(ScriptableObject data);
        // ScriptableObject GetCurrentSceneData();
    }
}