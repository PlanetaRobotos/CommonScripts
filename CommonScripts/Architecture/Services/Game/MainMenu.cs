using System.Collections;
using _Project.Scripts.CommonStuff.Mechanics;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Project.Scripts.Services
{
    public class MainMenu : BaseGame
    {
        private void Awake()
        {
            SetupGame();
        }
 
        protected override void BindGame()
        {
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