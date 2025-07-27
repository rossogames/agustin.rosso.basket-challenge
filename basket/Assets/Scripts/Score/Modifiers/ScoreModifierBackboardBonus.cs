using UnityEngine;

namespace Basket.Score.Modifiers
{
    [CreateAssetMenu(fileName = nameof(ScoreModifierBackboardBonus), menuName = "Basket/Score/BackboardBonus")]
    public class ScoreModifierBackboardBonus : ScoreModifier
    {
        public override int ApplyModifier(int currentPoints)
        {
            return currentPoints + Points;
        }
    }
}
