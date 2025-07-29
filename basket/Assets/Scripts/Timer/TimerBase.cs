using Rossoforge.Core.Events;
using Rossoforge.Services;

namespace Basket.Timer
{
    public class TimerBase
    {
        private ITimerService _timerService;
        protected IEventService _eventService;

        private bool _isStarted;

        protected float Duration { get; private set; }
        protected float CurrentTime { get; private set; }

        public TimerBase(float duration)
        {
            Duration = duration;

            _timerService = ServiceLocator.Get<ITimerService>();
            _eventService = ServiceLocator.Get<IEventService>();

            _timerService.RegisterTimer(this);
        }

        public void Start()
        {
            _isStarted = true;
            OnStart();
        }
        public void Update()
        {
            if (!_isStarted)
                return;

            CurrentTime += UnityEngine.Time.deltaTime;
            if (CurrentTime >= Duration)
            {
                OnTimerEnd();
                CurrentTime = 0f;
            }

            OnUpdate();
        }

        protected virtual void OnStart()
        {
        }
        protected virtual void OnUpdate()
        {
        }
        protected virtual void OnTimerEnd()
        {
            _isStarted = false;
            _timerService.UnregisterTimer(this);
        }
    }
}
