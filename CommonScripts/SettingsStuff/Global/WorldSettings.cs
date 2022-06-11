 using UnityEngine;

 namespace submodules.CommonScripts.CommonScripts.SettingsStuff.Global
{
    [CreateAssetMenu(fileName = "WorldSettings", menuName = "Settings/Global/WorldSettings")]
    public class WorldSettings : ScriptableObject
    {
        [SerializeField] private int _ballsAmount;
        [SerializeField] private float _minStartDistanceBetweenBalls;

        public int BallsAmount => _ballsAmount;

        public float MINStartDistanceBetweenBalls => _minStartDistanceBetweenBalls;
    }
}