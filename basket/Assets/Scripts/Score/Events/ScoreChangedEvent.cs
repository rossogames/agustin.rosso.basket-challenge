using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreChangedEvent : IEvent
    {
        public readonly int AppliedPoints;
        public readonly int TotalPoints;
        public readonly bool IsPerfectShot; 

        public ScoreChangedEvent(int appliedPoints, int totalPoints, bool isPerfectShot)
        {
            AppliedPoints = appliedPoints;
            TotalPoints = totalPoints;
            IsPerfectShot = isPerfectShot;
        }
    }
}
