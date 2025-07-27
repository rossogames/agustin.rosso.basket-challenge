using Basket.Score.Modifiers;
using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreModifierBackboardBonusAppliedEvent : IEvent
    {
        public readonly ScoreModifierBackboardBonus ScoreModifier;

        public ScoreModifierBackboardBonusAppliedEvent(ScoreModifierBackboardBonus scoreModifier)
        {
            ScoreModifier = scoreModifier;
        }
    }
}
