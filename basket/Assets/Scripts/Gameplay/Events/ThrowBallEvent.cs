using Rossoforge.Core.Events;
using UnityEngine;

namespace Basket
{
    public struct ThrowBallEvent : IEvent
    {
        public readonly Vector3 TargetPosition;
        public readonly float Angle;

        public ThrowBallEvent(Vector3 targetPosition, float angle)
        {
            TargetPosition = targetPosition;
            Angle = angle;
        }
    }
}
