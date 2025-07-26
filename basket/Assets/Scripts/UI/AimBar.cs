using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Basket.UI
{
    public class AimBar : MonoBehaviour,
        IEventListener<InputDragEvent>,
        IEventListener<AimStartedEvent>
    {
        private IEventService _eventService;
        private RectTransform _rectTransform;

        [SerializeField]
        private RectTransform _imageBasketTarget;

        [SerializeField]
        private RectTransform _imageBackboardTarget;

        [SerializeField]
        private Image _imageFiller;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<InputDragEvent>(this);
            _eventService.RegisterListener<AimStartedEvent>(this);
        }

        private void OnDisable()
        {
            _eventService.UnregisterListener<InputDragEvent>(this);
            _eventService.UnregisterListener<AimStartedEvent>(this);
        }

        public void OnEventInvoked(AimStartedEvent eventArg)
        {
            _rectTransform.sizeDelta = new Vector2(
                _rectTransform.sizeDelta.x,
                eventArg.AimUiHeight
            );

            InitializeTargetUI(_imageBasketTarget, eventArg.CurrentAimSetting.BasketTarget, eventArg.AimUiHeight);
            InitializeTargetUI(_imageBackboardTarget, eventArg.CurrentAimSetting.BackboardTarget, eventArg.AimUiHeight);
        }

        public void OnEventInvoked(InputDragEvent eventArg)
        {
            var distance = eventArg.EndScreenPos - eventArg.StartScreenPos;
            _imageFiller.fillAmount = distance.magnitude / _rectTransform.rect.height;
        }

        private void InitializeTargetUI(RectTransform rectTransform, AimTarget aimTarget, float aimUiHeight)
        {
            rectTransform.sizeDelta = new Vector2(
                rectTransform.sizeDelta.x,
                aimTarget.RelativeHeigh * aimUiHeight
            );

            rectTransform.anchoredPosition = new Vector2(
                rectTransform.anchoredPosition.x,
                 aimTarget.RelativePositionY * aimUiHeight
            );
        }
    }
}
