using Basket.Score.Modifiers;
using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreModifierAppliedEvent : IEvent
    {
        public readonly ScoreModifier ScoreModifier;

        public ScoreModifierAppliedEvent(ScoreModifier scoreModifier)
        {
            ScoreModifier = scoreModifier;
        }
    }
}
