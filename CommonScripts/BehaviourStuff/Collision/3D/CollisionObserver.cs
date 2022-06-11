using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.BehaviourStuff.Collision._3D
{
    public class CollisionObserver : MonoBehaviour
    {
        private ICollissible _parent;

        public void Setup(ICollissible parent) => _parent = parent;

        private void OnCollisionEnter(UnityEngine.Collision other) => _parent?.CollisionEnter(other);

        private void OnCollisionExit(UnityEngine.Collision other) => _parent?.CollisionExit(other);
    }
    
    public interface ICollissible
    {
        void CollisionEnter(UnityEngine.Collision other);
        void CollisionExit(UnityEngine.Collision other);
    }
}