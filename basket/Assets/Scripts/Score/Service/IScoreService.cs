using Basket.Score.Modifiers;
using Rossoforge.Core.Services;

namespace Basket.Score.Service
{
    public interface IScoreService : IService
    {
        void SetCurrentShootPoints(int points, bool isBackboard, bool isPerfectShot);
        void ApplyPoints();
        void AddModifier(ScoreModifierData modifier);
        void RemoveModifier(ScoreModifierData modifier);
        void ResetScore();
        int GetScore();
    }
}
