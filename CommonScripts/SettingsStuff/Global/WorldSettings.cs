 using UnityEngine;

 namespace submodules.CommonScripts.CommonScripts.SettingsStuff.Global
{
    [CreateAssetMenu(fileName = "WorldSettings", menuName = "Settings/Global/WorldSettings")]
    public class WorldSettings : ScriptableObject
    {
        [SerializeField] private float _ballOffset;

        public float BallOffset => _ballOffset;
    }
}