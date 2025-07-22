using Basket.Gameplay.Service;

namespace Basket.Gameplay.Phases
{
    public class GameplayIdlePhase : GameplayBasePhase
    {
        public GameplayIdlePhase(GameplayStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEventInvoked(GameplayLoadedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            StateMachine.TransitionTo(StateMachine.CountdownPhase);
        }
    }
}
