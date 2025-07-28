using Basket.Score.Modifiers;
using System;
using UnityEngine;

namespace Basket.Gameplay.Service
{
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
