using Basket.Gameplay.Events;
using Basket.Timer;
using System;

namespace Basket.Gameplay.Timers
{
    public class MatchTimer : TimerBase
    {
        private int _currentTimeSeconds;

        public MatchTimer(float matchDuration) : base(matchDuration)
        {
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
                _eventService.Raise(new MatchTimerUpdatedEvent(Duration - CurrentTime));
            }
        }

        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            _eventService.Raise(new MatchTimerEndedEvent());
        }
    }
}
