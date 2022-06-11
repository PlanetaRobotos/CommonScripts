using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using submodules.CommonScripts.CommonScripts.Utilities.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace submodules.CommonScripts.CommonScripts.UIStuff.Global
{
    public class PauseWindow : WindowBase
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _restartButton;

        public override void Initialize()
        {
            base.Initialize();
            
            CloseWindow(false);
            
            _closeButton.onClick.AddListener(OnResume);
            _restartButton.onClick.AddListener(OnRestart);
            _resumeButton.onClick.AddListener(OnResume);
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(OnResume);
            _restartButton.onClick.RemoveListener(OnRestart);
            _resumeButton.onClick.RemoveListener(OnResume);
        }

        private void OnResume()
        {
            _uiService.UnloadWindow(GetWindowType());
            _uiService.OpenWindow(WindowType.HUD, false, true, true);
        }

        private void OnRestart()
        {
            CommonTools.RestartScene();
        }

        public override WindowType GetWindowType() => WindowType.Pause;
    }
}