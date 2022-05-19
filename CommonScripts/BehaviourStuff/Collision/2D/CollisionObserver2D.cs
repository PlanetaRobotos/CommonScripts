using System;
using UnityEngine;

namespace _Project.Scripts.Architecture.Behaviours
{
    public class CollisionObserver2D : MonoBehaviour
    {
        private ICollissible2D _parent;

        public void Setup(ICollissible2D parent) => _parent = parent;
        
        private void OnCollisionEnter2D(Collision2D other) => _parent?.CollisionEnter(other);

        private void OnCollisionExit2D(Collision2D other) => _parent?.CollisionExit(other);
    }
    
    public interface ICollissible2D
    {
        void CollisionEnter(Collision2D other);
        void CollisionExit(Collision2D other);
    }
}