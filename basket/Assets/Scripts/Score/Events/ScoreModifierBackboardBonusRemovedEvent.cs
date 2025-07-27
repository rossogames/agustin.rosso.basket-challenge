using Basket.Score.Modifiers;
using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreModifierBackboardBonusRemovedEvent : IEvent
    {
        public readonly ScoreModifierBackboardBonus ScoreModifier;

        public ScoreModifierBackboardBonusRemovedEvent(ScoreModifierBackboardBonus scoreModifier)
        {
            ScoreModifier = scoreModifier;
        }
    }
}
