using System.Collections;
using _Project.Scripts.Mechanics;
using _Project.Scripts.Mechanics.Triggers;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class GameStartUp : BaseGame
    {
        [SerializeField] private Transform _gameCanvas;
        [SerializeField] private SplineTriggers _splineTriggers;
        [SerializeField] private Balls _balls;

        private IUIService _uiService;

        private HeroController _heroController;
        // private Levels _levels;

        [Inject]
        private void Construct(IUIService uiService, HeroController heroController)
        {
            // _levels = levels;
            _heroController = heroController;
            _uiService = uiService;
        }

        protected override void BindGame()
        {
            InitializeUI();

            // _levels.CreateLevel();

            // if (!_levels.TryGetLevel(out var level)) return;
            // Vector2 startPoint = level.GetStartPoint();
            _heroController.CreateHero();

            if (!_heroController.TryGetHero(out var hero)) return;
            // _heroController.SetStartPosition(startPoint);
            
            _balls.Initialize();
            
            _splineTriggers.Construct(hero);
            _splineTriggers.Initialize();
        }

        private void InitializeUI()
        {
            _uiService.Initialize(_gameCanvas);
            _uiService.OpenWindow(WindowType.HUD, true, false, true);
        }

        protected override IEnumerator LoadProcess()
        {
            yield return new WaitForSeconds(2);
            // ...
        }
    }
}