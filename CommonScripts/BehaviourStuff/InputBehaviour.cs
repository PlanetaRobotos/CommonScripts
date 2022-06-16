using System;
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
                var ray = _camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit, Mathf.Infinity, _clickableLayerMask))
                    ObjectMouseClick(hit.collider.gameObject);
            }
        }

        public event Action<GameObject> ObjectMouseClick = obj => { };
    }
}