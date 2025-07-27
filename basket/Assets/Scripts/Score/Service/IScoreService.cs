using Basket.Score.Modifiers;
using Rossoforge.Core.Services;

namespace Basket.Score.Service
{
    public interface IScoreService : IService
    {
        void SetCurrentShootPoints(int points);
        void ApplyPoints();
        void AddModifier(ScoreModifier modifier);
        void RemoveModifier(ScoreModifier modifier);
    }
}
