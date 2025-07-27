using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayAimPhaseData), menuName = "Basket/Gameplay/AimPhaseData")]
    public class GameplayAimPhaseData : ScriptableObject
    {
        public Vector3 CameraOffSet;

        public float MissOffset;

        public float AimUiHeight;

        public AimSetting[] Targets;
    }
}
