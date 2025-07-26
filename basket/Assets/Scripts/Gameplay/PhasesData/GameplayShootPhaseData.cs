using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayShootPhaseData), menuName = "Basket/Gameplay/ShootPhaseData")]
    public class GameplayShootPhaseData : ScriptableObject
    {
        public float WaitTime;
    }
}
