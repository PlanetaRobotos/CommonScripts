using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using submodules.CommonScripts.CommonScripts.Utilities.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace submodules.CommonScripts.CommonScripts.UIStuff.Global
{
    public class CompleteWindow : WindowBase
    {
        [SerializeField] private Button _continueButton;

        public override void Initialize()
        {
            base.Initialize();
            _continueButton.onClick.AddListener(Continue);
        }

        private void Continue()
        {
            CommonTools.RestartScene();
        }

        private void OpenOptions()
        {
            _uiService.OpenWindow(WindowType.Pause, true, true, true);
            CloseWindow(false);
        }

        public override WindowType GetWindowType() => WindowType.CompleteWindow;
    }
}