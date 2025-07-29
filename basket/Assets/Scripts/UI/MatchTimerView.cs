using Basket.Gameplay.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using TMPro;
using UnityEngine;

namespace Basket.Gameplay.UI
{
    public class MatchTimerView : MonoBehaviour,
        IEventListener<MatchTimerStartedEvent>,
        IEventListener<MatchTimerUpdatedEvent>,
        IEventListener<MatchTimerEndedEvent>
    {
        private IEventService _eventService;

        [SerializeField]
        private TextMeshProUGUI _timerText;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<MatchTimerStartedEvent>(this);
            _eventService.RegisterListener<MatchTimerUpdatedEvent>(this);
            _eventService.RegisterListener<MatchTimerEndedEvent>(this);
        }
        private void OnDisable()
        {
            _eventService.UnregisterListener<MatchTimerStartedEvent>(this);
            _eventService.UnregisterListener<MatchTimerUpdatedEvent>(this);
            _eventService.UnregisterListener<MatchTimerEndedEvent>(this);
        }

        public void OnEventInvoked(MatchTimerStartedEvent eventArg)
        {
            SetTimerText(0);
        }

        public void OnEventInvoked(MatchTimerUpdatedEvent eventArg)
        {
            SetTimerText(eventArg.CurrentMatchTime);
        }

        public void OnEventInvoked(MatchTimerEndedEvent eventArg)
        {
            SetTimerText(0);
        }

        private void SetTimerText(float time)
        {
            var timeSpan = System.TimeSpan.FromSeconds(time);
            _timerText.text = timeSpan.ToString(@"m\:ss");
        }
    }
}
