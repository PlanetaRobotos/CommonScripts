using System;
using UnityEngine;

namespace _Project.Scripts.Architecture.Behaviours
{
    public class CollisionObserver : MonoBehaviour
    {
        private ICollissible _parent;

        public void Setup(ICollissible parent) => _parent = parent;

        private void OnCollisionEnter(Collision other) => _parent?.CollisionEnter(other);

        private void OnCollisionExit(Collision other) => _parent?.CollisionExit(other);
    }
    
    public interface ICollissible
    {
        void CollisionEnter(Collision other);
        void CollisionExit(Collision other);
    }
}