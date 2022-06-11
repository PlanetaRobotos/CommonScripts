using System;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.SaveLoad.Data
{
    [Serializable]
    public class PlayerData
    {
        public int Level
        {
            get => _level;
            set => _level = value;
        }

        private int _level;
    }
}