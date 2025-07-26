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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _eventService.Raise<MatchTimeEndedEvent>();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _eventService.Raise(new AimCompletedEvent(ShootingTarget.Backboard, 0.95f, 1f));
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _eventService.Raise(new AimCompletedEvent(ShootingTarget.Basket, 1f, 0.95f));
            }

            _gameplayService.Update();
        }

        public void OnEventInvoked(MatchEndedEvent eventArg)
        {
            _popupMatchResult.Open();
        }
    }
}
