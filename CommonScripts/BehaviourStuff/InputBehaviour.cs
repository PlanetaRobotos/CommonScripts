using System;
using submodules.CommonScripts.CommonScripts.Utilities.Tools;
using UnityEngine;

namespace _Project.Scripts.Services.InputStuff
{
    public class InputBehaviour : MonoBehaviour
    {
        [SerializeField] private LayerMask _clickableLayerMask;
        
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // var ray = _camera.ScreenPointToRay(Input.mousePosition);
                // if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _clickableLayerMask))
                // {
                //     ObjectMouseClick(hit.collider.gameObject);
                //     Debug.Log($"3d {hit.collider.gameObject.name}");
                // }
                
                var ray2D = _camera.ScreenToWorldPoint(Input.mousePosition);
                var hit2D = Physics2D.Raycast(ray2D, Vector2.zero, Mathf.Infinity);
                if (hit2D.collider != null && !ScreenTools.IsPointerOverUIObject())
                {
                    ObjectMouseClick(hit2D.collider.gameObject, ray2D);
                    // Debug.Log($"2d {hit2D.collider.gameObject.name}");
                }
            }
        }

        public event Action<GameObject, Vector3> ObjectMouseClick = (obj, position) => { };
    }
}