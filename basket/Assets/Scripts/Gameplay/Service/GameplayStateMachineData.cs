using Basket.Gameplay.PhasesData;
using UnityEngine;

namespace Basket.Gameplay.Service
{
    [CreateAssetMenu(fileName = nameof(GameplayStateMachineData), menuName = "Basket/Gameplay/StateMachineData")]
    public class GameplayStateMachineData : ScriptableObject
    {
        [field: SerializeField]
        public GameplayCountdownPhaseData CountdownPhaseData { get; private set; }
    }
}
