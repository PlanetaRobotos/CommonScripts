using UnityEngine;

namespace _Project.Scripts.Architecture.Behaviours
{
    public class TriggerObserver2D : MonoBehaviour
    {
        private ITriggable2D _parent;

        public void Setup(ITriggable2D parent) => _parent = parent;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _parent?.CollisionEnter(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _parent?.CollisionExit(other);
        }
    }
    
    public interface ITriggable2D
    {
        void CollisionEnter(Collider2D other);
        void CollisionExit(Collider2D other);
    }
}