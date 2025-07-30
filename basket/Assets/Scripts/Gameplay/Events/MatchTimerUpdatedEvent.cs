using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct MatchTimerUpdatedEvent : IEvent
    {
        readonly public float RemainingMatchTime;

        public MatchTimerUpdatedEvent(float remainingMatchTime)
        {
            RemainingMatchTime = remainingMatchTime;
        }
    }
}
