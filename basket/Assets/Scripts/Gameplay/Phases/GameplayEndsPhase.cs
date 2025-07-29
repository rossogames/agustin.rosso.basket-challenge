using Basket.Gameplay.Events;
using Basket.Gameplay.Service;

namespace Basket.Gameplay.Phases
{
    public class GameplayEndsPhase : GameplayBasePhase
    {
        public GameplayEndsPhase(GameplayStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            RaiseGameplayEndedEvent();
        }

        private void RaiseGameplayEndedEvent()
        {
            _eventService.Raise<MatchEndedEvent>();
            // this open the result popup, then rise the GameplayEndedEvent
        }

        public override void OnEventInvoked(PopupMatchResultClosedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            _sceneService.ChangeScene("MatchResult");
        }
    }
}
