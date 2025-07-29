using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct MatchTimerEndedEvent : IEvent
    {
        public readonly float MatchEndedTime;

        public MatchTimerEndedEvent(float matchEndedTime)
        {
            MatchEndedTime = matchEndedTime;
        }
    }
}
