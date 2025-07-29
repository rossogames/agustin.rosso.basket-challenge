using System;
using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayAimPhaseData), menuName = "Basket/Gameplay/Phase - AimPhaseData")]
    public class GameplayAimPhaseData : ScriptableObject
    {
        public float CameraDistanceFromBall;
        public float MissOffset;
        public float AimUiHeight;
        public int PerfectShotScore;
        public int DefaultShotScore;
        public AimSetting[] Targets;
    }

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
        public float RelativeHeigh;
        public float RelativePositionY;
        public Vector3 TargetPosition;
        public float ThrowAngle;
    }
}
