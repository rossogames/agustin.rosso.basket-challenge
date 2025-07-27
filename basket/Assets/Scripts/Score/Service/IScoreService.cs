using Rossoforge.Core.Services;

namespace Basket.Score.Service
{
    public interface IScoreService : IService
    {
        void SetCurrentShootPoints(int points);
        void ApplyPoints();
    }
}
