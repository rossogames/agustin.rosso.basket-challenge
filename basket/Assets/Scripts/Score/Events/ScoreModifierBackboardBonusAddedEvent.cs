using Basket.Score.Modifiers;
using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreModifierBackboardBonusAddedEvent : IEvent
    {
        public readonly ScoreModifierBackboardBonus ScoreModifier;

        public ScoreModifierBackboardBonusAddedEvent(ScoreModifierBackboardBonus scoreModifier)
        {
            ScoreModifier = scoreModifier;
        }
    }
}
