using Basket.Score.Modifiers;
using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreModifierBackboardBonusAddedEvent : IEvent
    {
        public readonly ScoreModifierBackboardBonusData ScoreModifier;

        public ScoreModifierBackboardBonusAddedEvent(ScoreModifierBackboardBonusData scoreModifier)
        {
            ScoreModifier = scoreModifier;
        }
    }
}
