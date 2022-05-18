using System.Collections;
using _Project.Scripts.CommonStuff.Mechanics;
using _Project.Scripts.CommonStuff.Mechanics.BallStuff;
using UnityEngine;

namespace _Project.Scripts.Services
{
    public class Game : BaseGame
    {
        [SerializeField] private Scaler _gameField;
        [SerializeField] private Walls _walls;
        [SerializeField] private Balls _balls;

        protected override void BindGame()
        {
            _gameField.Initialize();
            _walls.Initialize();
            _balls.Initialize();
        }
 
        protected override IEnumerator LoadProcess()
        {
            yield return new WaitForSeconds(2);
            // CommandFactory.Get<LoadMainMenu>().Load(LoadSceneMode.Single);
        }
    }
}