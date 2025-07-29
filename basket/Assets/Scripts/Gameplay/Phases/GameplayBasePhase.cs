using Basket.Gameplay.Events;
using Basket.Gameplay.Service;
using Basket.General;
using Basket.Score.Service;
using Rossoforge.Core.Events;
using Rossoforge.Scenes.Service;
using Rossoforge.Services;

namespace Basket.Gameplay.Phases
{
    public class GameplayBasePhase : IState
    {
        protected readonly IEventService _eventService;
        protected readonly ISceneService _sceneService;
        protected readonly IScoreService _scoreService;
        protected GameplayStateMachine StateMachine { get; private set; }

        public GameplayBasePhase(GameplayStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            _eventService = ServiceLocator.Get<IEventService>();
            _sceneService = ServiceLocator.Get<ISceneService>();
            _scoreService = ServiceLocator.Get<IScoreService>();
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
        public virtual void Update()
        {
        }

        public virtual void OnEventInvoked(GameplayLoadedEvent eventArg)
        {
        }
        public virtual void OnEventInvoked(InputDragEndedEvent eventArg)
        {
        }
        public virtual void OnEventInvoked(MatchTimerEndedEvent eventArg)
        {
        }
        public virtual void OnEventInvoked(TargetHitEvent eventArg)
        {
        }
        public virtual void OnEventInvoked(GameplayEndedEvent eventArg)
        {
        }
    }
}
