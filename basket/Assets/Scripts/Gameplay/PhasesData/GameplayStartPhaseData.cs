using Basket.Score.Modifiers;
using System;
using UnityEngine;

namespace Basket.Gameplay.PhasesData
{
    [CreateAssetMenu(fileName = nameof(GameplayStartPhaseData), menuName = "Basket/Gameplay/Phase - StartPhaseData")]
    public class GameplayStartPhaseData : ScriptableObject
    {
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
            public ScoreModifierBackboardBonus[] Modifiers { get; private set; }
        }
    }
}
