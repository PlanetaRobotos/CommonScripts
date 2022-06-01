using UnityEngine;

namespace _Project.Scripts.Architecture.SettingsStuff
{
    [CreateAssetMenu(fileName = "WorldSettings", menuName = "Settings/Global/WorldSettings")]
    public class WorldSettings : ScriptableObject
    {
        [SerializeField] private int _ballsAmount;

        public int BallsAmount => _ballsAmount;
    }
}