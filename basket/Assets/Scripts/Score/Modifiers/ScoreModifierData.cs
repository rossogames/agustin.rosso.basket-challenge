using UnityEngine;

namespace Basket.Score.Modifiers
{
    public abstract class ScoreModifierData : ScriptableObject
    {
        [field: SerializeField]
        public ScoreModifierApplyMode ApplyMode { get; private set; }

        [field: SerializeField]
        public int Points { get; private set; }

        public string DisplayValue
        {
            get => $"+{Points}";
        }

        public abstract int ApplyModifier(int currentPoints);
    }
}
