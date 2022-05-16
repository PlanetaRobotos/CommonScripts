using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Services
{
    public class InitializeBehaviour : MonoBehaviour
    {
        private Queue<IInitialize> _initializes;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                foreach (IInitialize initializer in _initializes)
                {
                    initializer.Initialize();
                }   
            }
        }

        public void AddInitializer(IInitialize initializer) => _initializes.Enqueue(initializer);
        public void RemoveInitializer(IInitialize initializer) => _initializes.Enqueue(initializer);
    }
    
    public interface IInitialize
    {
        void Initialize();
    }
}