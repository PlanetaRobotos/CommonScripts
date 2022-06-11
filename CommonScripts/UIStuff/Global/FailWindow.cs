using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using submodules.CommonScripts.CommonScripts.Utilities.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace submodules.CommonScripts.CommonScripts.UIStuff.Global
{
    public class FailWindow : WindowBase
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
        
        public override WindowType GetWindowType() => WindowType.FailWindow;
    }
}