using Basket.Gameplay.Events;
using Basket.Timer;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using System;
using UnityEngine;

namespace Basket.Gameplay.Timers
{
    public class MatchTimer : TimerBase
    {
        private IEventService _eventService;
        private int _currentTimeSeconds;

        public MatchTimer(float matchDuration) : base(matchDuration)
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        protected override void OnStart()
        {
            base.OnStart();
            _eventService.Raise<MatchTimerStartedEvent>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            var seconds = (int)Math.Floor(CurrentTime);
            if (seconds > _currentTimeSeconds)
            {
                _currentTimeSeconds = seconds;
                _eventService.Raise(new MatchTimerUpdatedEvent(CurrentTime));
                Debug.Log($"Match Timer Updated: {CurrentTime} seconds");
            }
        }

        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            _eventService.Raise(new MatchTimerEndedEvent(Duration));
        }
    }
}
