using Basket.Gameplay.Service;

namespace Basket.Gameplay.Phases
{
    public class GameplayLoadPhase : GameplayBasePhase
    {
        public GameplayLoadPhase(GameplayStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEventInvoked(GameplayLoadedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            StateMachine.TransitionTo(StateMachine.CountdownPhase);
        }
    }
}
