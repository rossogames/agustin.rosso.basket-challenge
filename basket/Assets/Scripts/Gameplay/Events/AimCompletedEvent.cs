using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct AimCompletedEvent : IEvent
    {
        public readonly ShootingTarget Target;
        public readonly float AccuracyX;
        public readonly float AccuracyZ;

        public AimCompletedEvent(ShootingTarget target, float accuracyX, float accuracyZ)
        {
            Target = target;
            AccuracyX = accuracyX;
            AccuracyZ = accuracyZ;
        }
    }
}
