using System.Collections.Generic;

namespace Basket.Timer
{
    public class TimerService : ITimerService
    {
        private List<TimerBase> _timers;
        private readonly object _lock = new();

        public TimerService()
        {
            _timers = new List<TimerBase>();
        }

        public void RegisterTimer(TimerBase timer)
        {
            lock (_lock)
            {
                if (!_timers.Contains(timer))
                    _timers.Add(timer);
            }
        }

        public void UnregisterTimer(TimerBase timer)
        {
            lock (_lock)
            {
                _timers.Remove(timer);
            }
        }

        public void Update()
        {
            if (_timers.Count == 0)
                return;

            List<TimerBase> timersCopy;
            lock (_lock)
            {
                timersCopy = new List<TimerBase>(_timers);
            }

            foreach (var timer in timersCopy)
            {
                timer.Update();
            }
        }
    }
}
