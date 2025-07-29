using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreChangedEvent : IEvent
    {
        public readonly int AppliedPoints;
        public readonly int TotalPoints;

        public ScoreChangedEvent(int appliedPoints, int totalPoints)
        {
            AppliedPoints = appliedPoints;
            TotalPoints = totalPoints;
        }
    }
}
