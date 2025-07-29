using UnityEngine;

namespace Basket.Score.Modifiers
{
    [CreateAssetMenu(fileName = nameof(ScoreModifierBackboardBonusData), menuName = "Basket/Score/BackboardBonusData")]
    public class ScoreModifierBackboardBonusData : ScoreModifierData
    {
        [field: SerializeField]
        public float RandomWeight { get; private set; }

        public override int ApplyModifier(int currentPoints)
        {
            return currentPoints + Points;
        }
    }
}
