using Basket.Gameplay.Events;
using Basket.Gameplay.Popups.MatchResult;
using Basket.Gameplay.Service;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components
{
    public class GameplayHandler : MonoBehaviour, IEventListener<MatchEndedEvent>
    {
        [SerializeField]
        private PopupMatchResultView _popupMatchResult;

        private IEventService _eventService;    
        private IGameplayService _gameplayService;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _gameplayService = ServiceLocator.Get<IGameplayService>();

            _eventService.RegisterListener<MatchEndedEvent>(this);
        }

        private void Start()
        {
            _eventService.Raise<GameplayLoadedEvent>();
        }

        private void OnDestroy()
        {
            _eventService.UnregisterListener<MatchEndedEvent>(this);
        }

        private void LateUpdate()
        {
            _gameplayService.Update();
        }

        public void OnEventInvoked(MatchEndedEvent eventArg)
        {
            _popupMatchResult.Open();
        }
    }
}
