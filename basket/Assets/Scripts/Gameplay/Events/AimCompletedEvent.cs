using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct AimCompletedEvent : IEvent
    {
        public readonly ShootingTarget Target;
        public readonly float Accuracy;

        public AimCompletedEvent(ShootingTarget target, float accuracy)
        {
            Target = target;
            Accuracy = accuracy;
        }
    }
}
