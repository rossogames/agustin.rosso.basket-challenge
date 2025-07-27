using Basket.Gameplay.PhasesData;
using Rossoforge.Core.Events;

namespace Basket.Gameplay.Events
{
    public struct AimStartedEvent : IEvent
    {
        public readonly float AimUiHeight;
        public readonly float CameraDistanceFromBall;
        public readonly AimSetting CurrentAimSetting;

        public AimStartedEvent(float aimUiHeight, float cameraDistanceFromBall, AimSetting currentAimSetting)
        {
            AimUiHeight = aimUiHeight;
            CameraDistanceFromBall = cameraDistanceFromBall;
            CurrentAimSetting = currentAimSetting;
        }
    }
}
