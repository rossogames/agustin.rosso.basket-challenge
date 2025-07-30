using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct MatchTimerStartedEvent : IEvent
    {
        public readonly float MatchDuration;

        public MatchTimerStartedEvent(float matchDuration)
        {
            MatchDuration = matchDuration;
        }
    }
}
