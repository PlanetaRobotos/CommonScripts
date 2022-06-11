using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.SettingsStuff.Global
{
    [CreateAssetMenu(fileName = "UISettings", menuName = "Settings/Global/UISettings")]
    public class UISettings : ScriptableObject
    {
        [Header("Common")]
        [SerializeField] private float _openDuration = 0.2f;
        [SerializeField] private float _closeDuration = 0.2f;

        public float CloseDuration => _closeDuration;

        public float OpenDuration => _openDuration;
    }
}