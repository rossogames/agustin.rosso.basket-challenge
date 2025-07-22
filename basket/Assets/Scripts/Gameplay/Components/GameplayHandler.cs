using Basket.Gameplay.Popups.MatchResult;
using Basket.Gameplay.Service;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket
{
    public class GameplayHandler : MonoBehaviour, IEventListener<GameplayEndedEvent>
    {
        [SerializeField]
        private PopupMatchResultView _popupMatchResult;

        private IEventService _eventService;    
        private IGameplayService _gameplayService;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _gameplayService = ServiceLocator.Get<IGameplayService>();

            _eventService.RegisterListener<GameplayEndedEvent>(this);
        }

        private void Start()
        {
            _gameplayService.StartGame();
        }

        private void OnDestroy()
        {
            _eventService.UnregisterListener<GameplayEndedEvent>(this);
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _gameplayService.EndGame();
            }

            _gameplayService.Update();
        }

        public void OnEventInvoked(GameplayEndedEvent eventArg)
        {
            _popupMatchResult.Open();
        }
    }
}
