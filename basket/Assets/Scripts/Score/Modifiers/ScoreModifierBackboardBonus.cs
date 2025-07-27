using UnityEngine;

namespace Basket.Score.Modifiers
{
    [CreateAssetMenu(fileName = nameof(ScoreModifierBackboardBonus), menuName = "Basket/Score/BackboardBonus")]
    public class ScoreModifierBackboardBonus : ScoreModifier
    {
        [field: SerializeField]
        public float Probability { get; private set; }

        public override int ApplyModifier(int currentPoints)
        {
            return currentPoints + Points;
        }
    }
}
