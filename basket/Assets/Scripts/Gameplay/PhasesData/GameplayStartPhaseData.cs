using Basket.Gameplay.Service;
using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayStartPhaseData), menuName = "Basket/Gameplay/Phase - StartPhaseData")]
    public class GameplayStartPhaseData : ScriptableObject
    {
        [field: SerializeField]
        public BackboardBonusSettings BackboardBonus { get; private set; }
    }
}
