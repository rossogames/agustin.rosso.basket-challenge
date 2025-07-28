using Basket.Gameplay.Events;
using Basket.Gameplay.Mechanics;
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
        IEventListener<MatchTimeEndedEvent>,
        IEventListener<GameplayEndedEvent>
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
            _eventService.RegisterListener<MatchTimeEndedEvent>(this);
            _eventService.RegisterListener<GameplayEndedEvent>(this);

            StateMachine = new GameplayStateMachine(_data.StateMachineData);
            StateMachine.StartMachine(StateMachine.IdlePhase);

            new BackboardBonusInactiveTimer(_data).Start(); // when its completed will activate the backboard bonus
        }

        public void Dispose()
        {
            _eventService.UnregisterListener<GameplayLoadedEvent>(this);
            _eventService.UnregisterListener<InputDragEndedEvent>(this);
            _eventService.UnregisterListener<TargetHitEvent>(this);
            _eventService.UnregisterListener<MatchTimeEndedEvent>(this);
            _eventService.UnregisterListener<GameplayEndedEvent>(this);
        }

        public void Update()
        {
            StateMachine.Update();
        }

        public void OnEventInvoked(GameplayLoadedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(InputDragEndedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(TargetHitEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(MatchTimeEndedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(GameplayEndedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);

    }
}
