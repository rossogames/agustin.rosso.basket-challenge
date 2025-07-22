using Basket.Gameplay.Service;
using Basket.General;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayBasePhase : IState
    {
        protected readonly IEventService _eventService;

        protected GameplayStateMachine StateMachine { get; private set; }

        public GameplayBasePhase(GameplayStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            _eventService = ServiceLocator.Get<IEventService>();
        }

        public virtual void Enter()
        {
            Debug.LogWarning($"Entering {GetType().Name}");
        }

        public virtual void Exit()
        {
            Debug.LogWarning($"Exit {GetType().Name}");
        }

        public virtual void Update()
        {
        }

        public virtual void OnEventInvoked(GameplayLoadedEvent eventArg)
        { 
        }

        public virtual void OnEventInvoked(GameplayEndedEvent eventArg)
        {
        }

        public virtual void OnEventInvoked(MatchTimeEndedEvent eventArg)
        {
        }
    }
}
