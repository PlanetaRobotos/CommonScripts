using submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Mechanics
{
    public class Scaler : MonoBehaviour
    {
        [SerializeField] private ScaleType _scaleType;
        [SerializeField] private GameObject _gameFieldPrefab;

        private IInstantiate _instantiateProvider;

        public void Initialize()
        {
            // Scale();
            
        }

        [Inject]
        private void Construct(IInstantiate instantiateProvider)
        {
            _instantiateProvider = instantiateProvider;
        }

        private void Scale()
        {
            var screenValues = Utilities.Tools.ScreenTools.GetScreenValuesAspect();
            const float boardOffset = 0.1f;
            Vector3 scale = _gameFieldPrefab.transform.localScale;
            float delta = scale.y / scale.x;
            Vector3 fieldScale = Vector3.zero;

            switch (_scaleType)
            {
                case ScaleType.Width:
                    fieldScale = new Vector3(screenValues.Width, screenValues.Width * delta, 0);
                    break;
                case ScaleType.Height:
                    fieldScale = new Vector3(screenValues.Height * (1 / delta), screenValues.Height, 0);
                    break;
                case ScaleType.Fit:
                    fieldScale = new Vector3(screenValues.Width + boardOffset,
                        screenValues.Height + boardOffset, 0);
                    break;
                case ScaleType.TilingWidth:
                    float height = screenValues.Width * delta;
                    fieldScale = new Vector3(screenValues.Width, height, 0);
                    _instantiateProvider.Instantiate(_gameFieldPrefab, Vector3.up * height,
                        fieldScale,
                        transform);
                    _instantiateProvider.Instantiate(_gameFieldPrefab.gameObject, Vector3.down * height,
                        fieldScale,
                        transform);
                    break;
                case ScaleType.TilingHeight:
                    float width = screenValues.Height * delta;
                    fieldScale = new Vector3(width, screenValues.Height, 0);
                    _instantiateProvider.Instantiate(_gameFieldPrefab.gameObject, Vector3.left * width, fieldScale,
                        transform);
                    _instantiateProvider.Instantiate(_gameFieldPrefab.gameObject, Vector3.right * width, fieldScale,
                        transform);
                    break;
            }
            
            _instantiateProvider.Instantiate(_gameFieldPrefab.gameObject, Vector3.zero, fieldScale, transform);
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