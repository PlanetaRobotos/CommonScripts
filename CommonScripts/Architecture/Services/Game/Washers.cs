using System.Collections.Generic;
using _Project.Scripts.Mechanics.WasherStuff;
using _Project.Scripts.Services.InputStuff;
using submodules.CommonScripts.CommonScripts.Constants;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.Game
{
    public class Washers : MonoBehaviour, IListable
    {
        private readonly List<Washer> _washers = new();

        private InputBehaviour _inputBehaviour;
        private IWasherFactory _washerFactory;

        [Inject]
        private void Construct(InputBehaviour inputBehaviour, IWasherFactory washerFactory)
        {
            _washerFactory = washerFactory;
            _inputBehaviour = inputBehaviour;
        }

        public void Initialize()
        {
            _inputBehaviour.ObjectMouseClick += ScreenMouseClick;

            _washerFactory.Init();
        }

        private void ScreenMouseClick(GameObject obj, Vector3 position)
        {
            if (obj.layer != LayerMask.NameToLayer(Layers.GameField))
                return;
            
            Debug.Log(gameObject.name);

            Washer washer = CreateWasher(position);
            Add(washer);
        }

        private Washer CreateWasher(Vector3 at)
        {
            GameObject washerObj = _washerFactory.Create(WasherType.WasherSimple.ToString());
            Washer washer = washerObj.GetComponent<Washer>();
            washerObj.SetActive(true);
            washer.Construct(this, _inputBehaviour);
            washer.Initialize();
            var startPosition = new Vector3(at.x, at.y, 0);
            washer.SetPosition(startPosition);
            return washer;
        }

        public void Add<T>(T instance) where T : Component
        {
            _washers.Add((Washer)(Object)instance);
        }

        public void Release<T>(T instance) where T : Component
        {
            Washer washer = (Washer)(Object)instance;
            washer.gameObject.SetActive(false);
            _washerFactory.Release(washer.gameObject, WasherType.WasherSimple.ToString());
            _washers.Remove(washer);
        }
    }

    public interface IListable
    {
        void Add<T>(T instance) where T : Component;
        void Release<T>(T instance) where T : Component;
    }
}