using System.Collections;
using _Project.Scripts.CommonStuff.Mechanics;
using _Project.Scripts.CommonStuff.Mechanics.BallStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using UnityEngine;
using Zenject;
using Scaler = submodules.CommonScripts.CommonScripts.Mechanics.Scaler;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class Game : BaseGame
    {
        [SerializeField] private Transform _gameCanvas;

        [SerializeField] private Scaler _gameField;
        [SerializeField] private Walls _walls;
        [SerializeField] private Balls _balls;
        
        [Inject] private IUIService _uiService;

        protected override void BindGame()
        {
            InitializeUI();

            _gameField.Initialize();
            _walls.Initialize();
            _balls.Initialize();
        }

        private void InitializeUI()
        {
            _uiService.Initialize(_gameCanvas);

            _uiService.OpenWindow(WindowType.HUD, true, false, true);

        }

        protected override IEnumerator LoadProcess()
        {
            yield return new WaitForSeconds(2);
            // CommandFactory.Get<LoadMainMenu>().Load(LoadSceneMode.Single);
        }
    }
}