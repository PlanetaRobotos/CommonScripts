using System.Collections;
using System.Collections.Generic;
using submodules.CommonScripts.CommonScripts.Architecture.Services.AssetsStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.DataStuff;
using submodules.CommonScripts.CommonScripts.Constants;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff
{
    public class UIService : IUIService
    {
        private readonly List<WindowBase> _loadedWindows = new List<WindowBase>();
        private readonly IAssetService _assetService;
        private readonly DiContainer _diContainer;
        private readonly IDataService _dataService;

        public Transform GameCanvas { get; private set; }

        public UIService(IAssetService assetService, DiContainer diContainer, IDataService dataService)
        {
            _dataService = dataService;
            _diContainer = diContainer;
            _assetService = assetService;
        }

        public void Initialize(Transform gameCanvas)
        {
            GameCanvas = gameCanvas;
        }

        public WindowBase OpenWindow(WindowType windowType, bool needCreate, bool isSmooth, bool needOpen)
        {
            WindowBase windowBase = _loadedWindows.Find(window => window.GetWindowType() == windowType);

            if (needCreate && !windowBase)
            {
                var windowPrefab = _assetService.LoadWindow(windowType);
                var window = _diContainer.InstantiatePrefab(windowPrefab, GameCanvas).GetComponent<WindowBase>();
                window.Construct(_dataService, this);
                window.Initialize();
                _loadedWindows.Add(window);
                window.CloseWindow(false);
                if (needOpen)
                    window.OpenWindow(isSmooth);
                return window;
            }

            if (!needCreate && windowBase && !windowBase.IsWindowOpened)
            {
                windowBase.OpenWindow(isSmooth);
                return windowBase;
            }

            return null;
        }

        public void UnloadWindow(WindowType windowType)
        {
            var windowBase = _loadedWindows.Find(window => window.GetWindowType() == windowType);
            if (windowBase != null)
            {
                CloseWindow(windowBase, false);
                Object.Destroy(windowBase.gameObject);
                _loadedWindows.Remove(windowBase);
            }
        }

        public WindowBase[] LoadWindows()
        {
            var objects = _assetService.LoadObjectsByType(AssetPath.WindowsPath);
            var windows = new WindowBase[objects.Length];
            for (var i = 0; i < objects.Length; i++)
            {
                windows[i] = objects[i].GetComponent<WindowBase>();
                _loadedWindows.Add(windows[i]);
            }

            return windows;
        }

        public void CloseWindow(WindowBase window, bool isSmooth)
        {
            if (!window.IsWindowClosed)
            {
                window.CloseWindow(isSmooth);
                // _openedWindows.Remove(window);
            }
        }

        private readonly Dictionary<UIEventType, UIEvent> _eventDictionary = new Dictionary<UIEventType, UIEvent>();

        public void AddListener(UIEventType type, UnityAction<Hashtable> listener)
        {
            if (!_eventDictionary.TryGetValue(type, out var thisEvent))
            {
                thisEvent = new UIEvent();
                _eventDictionary.Add(type, thisEvent);
            }

            thisEvent.AddListener(listener);
        }

        public void RemoveListener(UIEventType type, UnityAction<Hashtable> listener)
        {
            if (_eventDictionary.TryGetValue(type, out var thisEvent))
                thisEvent.RemoveListener(listener);
        }

        public void TriggerEvent(UIEventType type, Hashtable param = null)
        {
            if (_eventDictionary.TryGetValue(type, out var thisEvent))
                thisEvent?.Invoke(param);
        }
    }
}