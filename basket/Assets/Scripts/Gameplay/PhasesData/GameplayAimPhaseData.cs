using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayAimPhaseData), menuName = "Basket/Gameplay/AimPhaseData")]
    public class GameplayAimPhaseData : ScriptableObject
    {
        public Vector3 CameraOffSet;

        public AimSetting[] Targets;
    }
}
