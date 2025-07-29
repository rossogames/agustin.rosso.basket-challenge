using Basket.Timer;

namespace Basket.Gameplay.Timers
{
    public class InputDragTimer : TimerBase
    {
        public InputDragTimer(float duration) : base(duration)
        {
        }

        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            _eventService.Raise<InputDragCanceledEvent>();
        }
    }
}
