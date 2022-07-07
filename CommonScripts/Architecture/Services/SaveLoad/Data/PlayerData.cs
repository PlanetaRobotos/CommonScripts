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

        public int TilePositionIndex    
        {
            get => _tilePositionIndex;
            set => _tilePositionIndex = value;
        }

        private int _level;
        private int _tilePositionIndex;
    }
}