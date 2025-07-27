using UnityEngine;

namespace Basket.Score.Modifiers
{
    public abstract class ScoreModifier : ScriptableObject
    {
        [field: SerializeField]
        public int Points { get; private set; }

        public string DisplayValue
        {
            get => $"+{Points}";
        }

        public abstract int ApplyModifier(int currentPoints);
    }
}
