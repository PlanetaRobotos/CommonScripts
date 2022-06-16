using _Project.Scripts.Mechanics;
using submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff;
using UnityEngine;
using Zenject;
using IInstantiator = submodules.CommonScripts.CommonScripts.Architecture.Services.InstantiateStuff.IInstantiator;

namespace submodules.CommonScripts.CommonScripts.Mechanics
{
    public class Scaler : MonoBehaviour
    {
        [SerializeField] private ScaleType _scaleType;
        [SerializeField] private GameObject _gameFieldPrefab;

        private IInstantiator instantiatorProvider;

        public void Initialize()
        {
            // Scale();
            
        }

        [Inject]
        private void Construct(IInstantiator instantiatorProvider)
        {
            this.instantiatorProvider = instantiatorProvider;
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
                    instantiatorProvider.Instantiate<GameField>(_gameFieldPrefab.gameObject, Vector3.up * height,
                        fieldScale,
                        transform);
                    instantiatorProvider.Instantiate<GameField>(_gameFieldPrefab.gameObject, Vector3.down * height,
                        fieldScale,
                        transform);
                    break;
                case ScaleType.TilingHeight:
                    float width = screenValues.Height * delta;
                    fieldScale = new Vector3(width, screenValues.Height, 0);
                    instantiatorProvider.Instantiate<GameField>(_gameFieldPrefab.gameObject, Vector3.left * width, fieldScale,
                        transform);
                    instantiatorProvider.Instantiate<GameField>(_gameFieldPrefab.gameObject, Vector3.right * width, fieldScale,
                        transform);
                    break;
            }
            
            instantiatorProvider.Instantiate<GameField>(_gameFieldPrefab.gameObject, Vector3.zero, fieldScale, transform);
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