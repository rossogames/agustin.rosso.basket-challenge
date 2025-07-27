using Rossoforge.Core.Services;

namespace Basket.Gameplay.Service
{
    public interface IScoreService : IService
    {
        void SetCurrentShootPoints(int points);
        void ApplyPoints();
    }
}
