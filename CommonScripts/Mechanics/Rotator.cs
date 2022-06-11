using UnityEngine;

namespace submodules.CommonScripts.CommonScripts.Mechanics
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _speed;
    
        private void FixedUpdate()
        {
            transform.localEulerAngles += new Vector3(0, 0, _speed);
        }
    }
}
