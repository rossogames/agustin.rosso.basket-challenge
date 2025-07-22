using Rossoforge.Core.Events;
using Rossoforge.Core.Services;
using Rossoforge.Services;
using System;

namespace Basket.Gameplay.Service
{
    public class GameplayService : IGameplayService, IInitializable, IDisposable,
        IEventListener<GameplayLoadedEvent>,
        IEventListener<MatchTimeEndedEvent>,
        IEventListener<GameplayEndedEvent>
    {
        private IEventService _eventService;

        private GameplayStateMachineData _data;

        public GameplayStateMachine StateMachine { get; private set; }

        public GameplayService(GameplayStateMachineData data)
        {
            _data = data;
        }

        public void Initialize()
        {
            _eventService = ServiceLocator.Get<IEventService>();

            _eventService.RegisterListener<GameplayLoadedEvent>(this);
            _eventService.RegisterListener<MatchTimeEndedEvent>(this);
            _eventService.RegisterListener<GameplayEndedEvent>(this);

            StateMachine = new GameplayStateMachine(_data);
            StateMachine.StartMachine(StateMachine.IdlePhase);
        }

        public void Dispose()
        {
            _eventService.UnregisterListener<GameplayLoadedEvent>(this);
            _eventService.UnregisterListener<MatchTimeEndedEvent>(this);
            _eventService.UnregisterListener<GameplayEndedEvent>(this);
        }

        public void Update()
        {
            StateMachine.Update();
        }

        public void OnEventInvoked(GameplayLoadedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(MatchTimeEndedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
        public void OnEventInvoked(GameplayEndedEvent eventArg) => StateMachine.CurrentState?.OnEventInvoked(eventArg);
    }
}
