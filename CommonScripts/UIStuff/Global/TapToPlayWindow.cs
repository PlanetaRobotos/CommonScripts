using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using UnityEngine;
using UnityEngine.UI;

namespace submodules.CommonScripts.CommonScripts.UIStuff.Global
{
    public class TapToPlayWindow : WindowBase
    {
        [SerializeField] private Button _playButton;

        public override void Initialize()
        {
            base.Initialize();
            _playButton.onClick.AddListener(Play);
        }

        private void Play()
        {
            _uiService.TriggerEvent(UIEventType.GameStartedAction);
            _uiService.OpenWindow(WindowType.HUD, false, true, true);
            CloseWindow(false);
        }

        public override WindowType GetWindowType() => WindowType.TapToPlayWindow;
    }
}