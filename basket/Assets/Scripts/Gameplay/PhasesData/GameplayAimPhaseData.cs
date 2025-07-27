using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayAimPhaseData), menuName = "Basket/Gameplay/AimPhaseData")]
    public class GameplayAimPhaseData : ScriptableObject
    {
        public float CameraDistanceFromBall;
        public float MissOffset;
        public float AimUiHeight;
        public int PerfectShotScore;
        public int DefaultShotScore;
        public AimSetting[] Targets;
    }
}
