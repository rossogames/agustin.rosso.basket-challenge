using Basket.Gameplay.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Basket.Gameplay.Components.UI
{
    public class SwipeFeedback : MonoBehaviour, 
        IEventListener<InputDragEvent>,
        IEventListener<AimStartedEvent>,
        IEventListener<ThrowBallEvent>,
        IEventListener<MatchEndedEvent>
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
            _eventService.RegisterListener<AimStartedEvent>(this);
            _eventService.RegisterListener<ThrowBallEvent>(this);
            _eventService.RegisterListener<MatchEndedEvent>(this);
        }

        private void OnDisable()
        {
            _eventService.UnregisterListener<InputDragEvent>(this);
            _eventService.UnregisterListener<AimStartedEvent>(this);
            _eventService.UnregisterListener<ThrowBallEvent>(this);
            _eventService.UnregisterListener<MatchEndedEvent>(this);
        }

        public void OnEventInvoked(InputDragEvent eventArg)
        {
            ShowLine(eventArg);
        }
        public void OnEventInvoked(AimStartedEvent eventArg)
        {
            SetLineSize(0);
            _lineImage.enabled = true;
        }
        public void OnEventInvoked(ThrowBallEvent eventArg)
        {
            _lineImage.enabled = false;
        }
        public void OnEventInvoked(MatchEndedEvent eventArg)
        {
            _lineImage.enabled = false;
        }

        private void ShowLine(InputDragEvent eventArg)
        {
            var distance = eventArg.EndScreenPos - eventArg.StartScreenPos;

            _lineImage.transform.position = eventArg.StartScreenPos;
            SetLineSize(distance.magnitude);

            float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
            _lineImage.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        private void SetLineSize(float height)
        {
            _lineImage.rectTransform.sizeDelta = new Vector2(_lineImage.rectTransform.sizeDelta.x, height);
        }
    }
}
