 using UnityEngine;

 namespace submodules.CommonScripts.CommonScripts.SettingsStuff.Global
{
    [CreateAssetMenu(fileName = "WorldSettings", menuName = "Settings/Global/WorldSettings")]
    public class WorldSettings : ScriptableObject
    {
        [SerializeField] private int cachedTilesAmount = 15;
        [SerializeField] private float maxDistanceBetweenHeroAndTile;

        public int CachedTilesAmount => cachedTilesAmount;

        public float MAXDistanceBetweenHeroAndTile => maxDistanceBetweenHeroAndTile;
    }
}