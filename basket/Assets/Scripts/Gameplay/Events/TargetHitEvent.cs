using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct TargetHitEvent : IEvent
    {
        public int TriggerIndex;

        public TargetHitEvent(int triggerIndex)
        {
            TriggerIndex = triggerIndex;
        }
    }
}
