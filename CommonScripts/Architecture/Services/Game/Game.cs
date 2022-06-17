using System.Collections;
using _Project.Scripts.Mechanics;
using _Project.Scripts.Mechanics.BallStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class Game : BaseGame
    {
        [SerializeField] private Transform _gameCanvas;

        [SerializeField] private GameFieldBehaviour _gameFieldBehaviour;
        [SerializeField] private Washers _washers;
        [SerializeField] private Balls _balls;

        [Inject] private IUIService _uiService;

        protected override void BindGame()
        {
            InitializeUI();

            _gameFieldBehaviour.Initialize();
            _balls.Construct(_gameFieldBehaviour.GameField.GetComponent<GameFieldCollision>());
            _balls.Initialize();
            _washers.Initialize();
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