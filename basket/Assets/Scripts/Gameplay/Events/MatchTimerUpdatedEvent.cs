using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct MatchTimerUpdatedEvent : IEvent
    {
        readonly public float CurrentMatchTime;

        public MatchTimerUpdatedEvent(float currentMatchTime)
        {
            CurrentMatchTime = currentMatchTime;
        }
    }
}
