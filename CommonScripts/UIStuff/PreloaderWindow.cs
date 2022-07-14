using _Project.Scripts;
using DG.Tweening;
using PlasticPipe.Certificates;
using submodules.CommonScripts.CommonScripts.Architecture.Services.SceneStuff;
using submodules.CommonScripts.CommonScripts.Architecture.Services.UIStuff;
using submodules.CommonScripts.CommonScripts.Constants;
using submodules.CommonScripts.CommonScripts.UIStuff.Base;
using UnityEngine;
using Zenject;

namespace submodules.CommonScripts.CommonScripts.UIStuff
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PreloaderWindow : WindowBase
    {
        [SerializeField] private float _fadeDuration;
        [SerializeField] private float _delayBeforeFading;
        
        
        [SerializeField, Header("Sub Behaviours")] private FadingIconAnimator fadingIconAnimator;

        private CanvasGroup _canvasGroup;
        private ISceneService _sceneService;

        [Inject]
        private void Construct(ISceneService sceneService)
        {
            _sceneService = sceneService;
        }

        public override void Initialize()
        {
            base.Initialize();

            _canvasGroup = GetComponent<CanvasGroup>();
            
            fadingIconAnimator.Initialize();
            fadingIconAnimator.BeginFadeFlash();

            DOVirtual.DelayedCall(_delayBeforeFading, () =>
            {
                fadingIconAnimator.StopFadeFlash();
                CloseAnimate(true);
            });
        }

        protected override void CloseAnimate(bool isSmooth)
        {
            _canvasGroup.DOFade(0f, _fadeDuration).SetEase(Ease.OutSine).Play().onComplete += OnFadeComplete;
        }
        
        private void OnFadeComplete()
        {
            _sceneService.GoToScene(Scenes.Game);
        }

        public override WindowType GetWindowType() => WindowType.Preloader;
    }
}