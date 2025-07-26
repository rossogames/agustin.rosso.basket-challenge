using System;
using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [Serializable]
    public class AimSetting
    {
        public Vector3 BallPosition;
        public AimTarget BasketTarget;
        public AimTarget BackboardTarget;
    }

    [Serializable]
    public class AimTarget
    {
        public Vector3 TargetPosition;
        public float ThrowAngle;
    }
}
