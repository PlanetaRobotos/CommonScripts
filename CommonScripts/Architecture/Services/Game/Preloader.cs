using System.Collections;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class Preloader : BaseGame
    {
        [SerializeField] private Transform _gameCanvas;

        private IUIService _uiService;

        [Inject]
        private void Construct(IUIService uiService)
        {
            _uiService = uiService;
        }
        
        private void Awake()
        {
            SetupGame();
        }
 
        protected override void BindGame()
        {
            InitializeUI();

        }
        
        private void InitializeUI()
        {
            _uiService.Initialize(_gameCanvas);
            _uiService.OpenWindow(WindowType.Preloader, true, false, true);
        }
 
        protected override IEnumerator LoadProcess()
        {
            yield return new WaitForSeconds(2);
            // CommandFactory.Get<LoadMainMenu>().Load(LoadSceneMode.Single);
        }
    }

    public interface ILoadMainMenu
    {
        void Load(LoadSceneMode loadSceneMode);
    }

    public class LoadMainMenu : ILoadMainMenu
    {
        public void Load(LoadSceneMode loadSceneMode)
        {
            SceneManager.LoadScene("Game", loadSceneMode);
        }
    }

    // public class CommandFactory
    // {
    //     public static T Get<T>() where T : MonoBehaviour
    //     {
    //         return T;
    //     }
    // }
}