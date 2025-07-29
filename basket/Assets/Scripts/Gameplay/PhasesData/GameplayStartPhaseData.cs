using Basket.Score.Modifiers;
using System;
using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayStartPhaseData), menuName = "Basket/Gameplay/Phase - StartPhaseData")]
    public class GameplayStartPhaseData : ScriptableObject
    {
        [field: SerializeField]
        public float MatchDuration { get; private set; }

        [field: SerializeField]
        public float AimDragDuration { get; private set; }

        [field: SerializeField]
        public BackboardBonusSettings BackboardBonus { get; private set; }

        [Serializable]
        public class BackboardBonusSettings
        {
            [field: SerializeField]
            public float TimeInactive { get; private set; }

            [field: SerializeField]
            public float TimeActive { get; private set; }

            [field: SerializeField]
            public ScoreModifierBackboardBonusData[] Modifiers { get; private set; }
        }
    }
}
