using Rossoforge.Core.Events;
using UnityEngine;

namespace Basket.Gameplay.Events
{
    public struct AimStartedEvent : IEvent
    {
        public readonly Vector3 BallPosition;

        public AimStartedEvent(Vector3 ballPosition)
        {
            BallPosition = ballPosition;
        }
    }
}
