using Basket.Score.Modifiers;
using Rossoforge.Core.Events;

namespace Basket.Score.Events
{
    public struct ScoreModifierAppliedEvent : IEvent
    {
        public readonly ScoreModifierData ScoreModifier;

        public ScoreModifierAppliedEvent(ScoreModifierData scoreModifier)
        {
            ScoreModifier = scoreModifier;
        }
    }
}
