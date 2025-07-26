using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Basket.UI
{
    public class AimBar : MonoBehaviour, IEventListener<InputDragEvent>
    {
        private IEventService _eventService;

        [SerializeField]
        private RectTransform _transformInnerBackground;

        [SerializeField]
        private Image _imageFiller;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<InputDragEvent>(this);
        }

        private void OnDisable()
        {
            _eventService.UnregisterListener<InputDragEvent>(this);
        }

        public void OnEventInvoked(InputDragEvent eventArg)
        {
            var distance = eventArg.EndScreenPos - eventArg.StartScreenPos;
            _imageFiller.fillAmount = distance.magnitude / _transformInnerBackground.rect.height;
        }
    }
}
