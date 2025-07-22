using Rossoforge.Core.Services;

namespace Basket.Gameplay.Service
{
    public interface IGameplayService: IService
    {
        void StartGame();
        void Update();
        void EndGame();
    }
}
