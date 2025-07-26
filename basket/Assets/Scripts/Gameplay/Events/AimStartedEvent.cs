using Basket.Gameplay.PhasesData;
using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct AimStartedEvent : IEvent
    {
        public readonly float AimUiHeight;
        public readonly AimSetting CurrentAimSetting;

        public AimStartedEvent(float aimUiHeight, AimSetting currentAimSetting)
        {
            AimUiHeight = aimUiHeight;
            CurrentAimSetting = currentAimSetting;
        }
    }
}
