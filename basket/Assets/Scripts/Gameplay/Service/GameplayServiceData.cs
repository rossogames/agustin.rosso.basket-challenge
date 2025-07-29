using Basket.Gameplay.PhasesData;
using UnityEngine;

namespace Basket.Gameplay.Service
{
    [CreateAssetMenu(fileName = nameof(GameplayServiceData), menuName = "Basket/Gameplay/ServiceData")]
    public class GameplayServiceData : ScriptableObject
    {
        [field: SerializeField]
        public GameplayStartPhaseData StartPhaseData { get; private set; }

        [field: SerializeField]
        public GameplayAimPhaseData AimPhaseData { get; private set; }

        [field: SerializeField]
        public GameplayShootPhaseData ShootPhaseData { get; private set; }
    }
}
