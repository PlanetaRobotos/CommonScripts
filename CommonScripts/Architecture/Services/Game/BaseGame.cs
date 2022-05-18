using System;
using System.Collections;
using UnityEngine;

namespace _Project.Scripts.Services
{
    public class BaseGame : MonoBehaviour
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
            // StartCoroutine(LoadProcess());
        }
    }
}