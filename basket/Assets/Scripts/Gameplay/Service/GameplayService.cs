using Basket.Gameplay.Events;
using Rossoforge.Core.Events;
using Rossoforge.Core.Services;
using Rossoforge.Services;
using System;

namespace Basket.Gameplay.Service
{
    public class GameplayService : IGameplayService, IInitializable, IDisposable,
        IEventListener<GameplayLoadedEvent>,
        IEventListener<InputDragEndedEvent>,
        IEventListener<TargetHitEvent>,
        IEventListener<MatchTimerEndedEvent>,
        IEventListener<PopupMatchResultClosedEvent>
    {
        private IEventService _eventService;
        private GameplayServiceData _data;

        public GameplayStateMachine StateMachine { get; private set; }

        public GameplayService(GameplayServiceData data)
        {
            _data = data;
        }

        public void Initialize()
        {
            _eventService = ServiceLocator.Get<IEventService>();

            _eventService.RegisterListener<GameplayLoadedEvent>(this);
            _eventService.RegisterListener<InputDragEndedEvent>(this);
            _eventService.RegisterListener<TargetHitEvent>(this);
            _eventService.RegisterListener<MatchTimerEndedEvent>(this);
            _eventService.RegisterListener<PopupMatchResultClosedEvent>(this);
        }

        public void Dispose()
        {
            _eventService.UnregisterListener<GameplayLoadedEvent>(this);
            _eventService.UnregisterListener<InputDragEndedEvent>(this);
            _eventService.UnregisterListener<TargetHitEvent>(this);
            _eventService.UnregisterListener<MatchTimerEndedEvent>(this);
            _eventService.UnregisterListener<PopupMatchResultClosedEvent>(this);
        }

        public void Update()
        {
            StateMachine?.Update();
        }

        public void OnEventInvoked(GameplayLoadedEvent eventArg)
        {
            StateMachine = new GameplayStateMachine(_data);
            StateMachine.StartMachine(StateMachine.StartPhase);

            StateMachine.CurrentState?.OnEventInvoked(eventArg);
        }
        public void OnEventInvoked(InputDragEndedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(TargetHitEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(MatchTimerEndedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(PopupMatchResultClosedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);

    }
}
