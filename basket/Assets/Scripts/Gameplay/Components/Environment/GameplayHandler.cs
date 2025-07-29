using Basket.Gameplay.Events;
using Basket.Gameplay.Popups.MatchResult;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components.Environment
{
    public class GameplayHandler : MonoBehaviour, IEventListener<MatchEndedEvent>
    {
        [SerializeField]
        private PopupMatchResultView _popupMatchResult;

        private IEventService _eventService;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
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

        public void OnEventInvoked(MatchEndedEvent eventArg)
        {
            _popupMatchResult.Open();
        }
    }
}
