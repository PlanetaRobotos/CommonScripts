using System.Collections;
using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public abstract class BaseGame : MonoBehaviour
    {
        private void Start()
        {
            SetupGame();
        }

        protected virtual IEnumerator LoadProcess()
        {
            yield return null;
        }

        protected virtual void BindGame()
        {
            
        }

        protected void SetupGame()
        {
            BindGame();
            StartCoroutine(LoadProcess());
        }
    }
}