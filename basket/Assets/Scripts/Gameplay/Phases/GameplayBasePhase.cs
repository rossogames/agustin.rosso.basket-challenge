using Basket.Gameplay.Events;
using Basket.Gameplay.Service;
using Basket.General;
using Rossoforge.Core.Events;
using Rossoforge.Scenes.Service;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayBasePhase : IState
    {
        protected readonly IEventService _eventService;
        protected readonly ISceneService _sceneService;
        protected GameplayStateMachine StateMachine { get; private set; }

        public GameplayBasePhase(GameplayStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            _eventService = ServiceLocator.Get<IEventService>();
            _sceneService = ServiceLocator.Get<ISceneService>();
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
