using System.Collections;
using _Project.Scripts.Mechanics;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class Game : BaseGame
    {
        [SerializeField] private Transform _gameCanvas;

        private IUIService _uiService;
        private HeroController _heroController;
        private Levels _levels;

        [Inject]
        private void Construct(IUIService uiService, HeroController heroController, Levels levels)
        {
            _levels = levels;
            _heroController = heroController;
            _uiService = uiService;
        }

        protected override void BindGame()
        {
            InitializeUI();
            
            _heroController.CreateHero();

            _levels.CreateLevel();
        }

        private void InitializeUI()
        {
            _uiService.Initialize(_gameCanvas);
            _uiService.OpenWindow(WindowType.HUD, true, false, true);
        }

        protected override IEnumerator LoadProcess()
        {
            yield return new WaitForSeconds(2);
            
            
        }
    }
}