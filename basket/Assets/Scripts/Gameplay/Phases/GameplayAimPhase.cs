using Basket.Gameplay.Service;

namespace Basket.Gameplay.Phases
{
    public class GameplayAimPhase : GameplayBasePhase
    {
        public GameplayAimPhase(GameplayStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEventInvoked(MatchTimeEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            StateMachine.TransitionTo(StateMachine.MatchEndPhase);
        }
    }
}
