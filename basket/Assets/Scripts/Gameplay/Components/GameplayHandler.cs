using Basket.Gameplay.Service;
using Rossoforge.Services;
using UnityEngine;

namespace Basket
{
    public class GameplayHandler : MonoBehaviour
    {
        private IGameplayService _gameplayService;

        private void Awake()
        {
            _gameplayService = ServiceLocator.Get<IGameplayService>();
        }

        void Start()
        {
            _gameplayService.StartGame();
        }
    }
}
