using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;

namespace Basket.Gameplay.Phases
{
    public class GameplayCountdownPhase : GameplayBasePhase
    {
        private readonly GameplayCountdownPhaseData _data;

        public GameplayCountdownPhase(GameplayStateMachine stateMachine, GameplayCountdownPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override void Enter()
        {
            base.Enter();
            StateMachine.TransitionTo(StateMachine.AimPhase);
        }
    }
}
