using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using UnityEngine;
using UnityEngine.UI;

namespace submodules.CommonScripts.CommonScripts.UIStuff.Global
{
    public class HUDWindow : WindowBase
    {
        [SerializeField] private Button _openOptionsButton;

        private float _levelTime;

        public override void Initialize()
        {
            base.Initialize();
            _openOptionsButton.onClick.AddListener(OpenOptions);
        }

        private void OpenOptions()
        {
            _uiService.OpenWindow(WindowType.Pause, true, true, true);
            CloseWindow(false);
        }

        public override WindowType GetWindowType() => WindowType.HUD;
    }
}