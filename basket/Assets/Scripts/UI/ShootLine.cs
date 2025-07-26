using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Basket.UI
{
    public class ShootLine : MonoBehaviour, IEventListener<InputDragEvent>
    {
        private IEventService _eventService;

        [SerializeField]
        private Image _lineImage;

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

            _lineImage.transform.position = eventArg.StartScreenPos;
            _lineImage.rectTransform.sizeDelta = new Vector2(15, distance.magnitude);

            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            _lineImage.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }
}
