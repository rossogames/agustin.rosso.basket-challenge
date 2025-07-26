using System;
using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [Serializable]
    public class AimTarget
    {
        public Vector3 BallPosition;
        public Vector3 TargetPosition;
        public float ThrowAngle;
    }
}
