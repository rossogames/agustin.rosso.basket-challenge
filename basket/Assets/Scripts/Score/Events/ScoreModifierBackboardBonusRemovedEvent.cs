using Basket.Score.Modifiers;
using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreModifierBackboardBonusRemovedEvent : IEvent
    {
        public readonly ScoreModifierBackboardBonusData ScoreModifier;

        public ScoreModifierBackboardBonusRemovedEvent(ScoreModifierBackboardBonusData scoreModifier)
        {
            ScoreModifier = scoreModifier;
        }
    }
}
