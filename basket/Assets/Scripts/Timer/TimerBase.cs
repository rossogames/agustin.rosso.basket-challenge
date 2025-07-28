using Rossoforge.Services;

namespace Basket.Timer
{
    public class TimerBase
    {
        private ITimerService _timerService;
        private float _duration;
        private float _currentTime;
        private bool _isStarted;

        public bool IsPendingRemove { get; private set; }

        public TimerBase(float duration)
        {
            _duration = duration;

            _timerService = ServiceLocator.Get<ITimerService>();
            _timerService.RegisterTimer(this);
        }

        public virtual void Start()
        {
            _isStarted = true;
        }

        public void Update()
        {
            if (!_isStarted)
                return;

            _currentTime += UnityEngine.Time.deltaTime;
            if(_currentTime >= _duration)
            {
                OnTimerEnd();
                _currentTime = 0f; 
            }
        }

        protected virtual void OnTimerEnd()
        {
            _timerService.UnregisterTimer(this);
        }
    }
}
