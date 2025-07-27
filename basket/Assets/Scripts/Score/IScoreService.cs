using Rossoforge.Core.Services;

namespace Basket.Gameplay.Score
{
    public interface IScoreService : IService
    {
        void SetCurrentShootPoints(int points);
        void ApplyPoints();
    }
}
