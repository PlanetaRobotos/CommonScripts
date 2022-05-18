using System;
using _Project.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.CommonStuff.Mechanics
{
    public class Scaler : MonoBehaviour
    {
        [SerializeField] private ScaleType _scaleType;
        
        public void Initialize()
        {
            Scale();
        }

        private void Scale()
        {
            var screenValues = ScreenTools.GetScreenValues();
            const float boardOffset = 0.1f;
            Vector3 scale = transform.localScale;
            float delta = scale.y / scale.x;

            switch (_scaleType)
            {
                case ScaleType.Width:
                    transform.localScale = new Vector3(screenValues.Width, screenValues.Width * delta, 0);
                    break;
                case ScaleType.Height:
                    transform.localScale = new Vector3(screenValues.Height * (1 / delta), screenValues.Height, 0);
                    break;
                case ScaleType.Fit:
                    transform.localScale = new Vector3(screenValues.Width + boardOffset,
                        screenValues.Height + boardOffset, 0);
                    break;
                case ScaleType.TilingWidth:
                    float height = screenValues.Width * delta;
                    transform.localScale = new Vector3(screenValues.Width, height, 0);
                    Instantiate(gameObject, transform.position + Vector3.up * height, Quaternion.identity);
                    Instantiate(gameObject, transform.position - Vector3.up * height, Quaternion.identity);
                    break;
                case ScaleType.TilingHeight:
                    break;
            }
        }
    }

    internal enum ScaleType
    {
        Width,
        TilingWidth,
        TilingHeight,
        Height,
        Fit
    }
}