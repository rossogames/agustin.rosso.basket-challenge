using Basket.Gameplay.Timers;
using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;

namespace Basket.Gameplay.Phases
{
    public class GameplayStartPhase : GameplayBasePhase
    {
        private readonly GameplayStartPhaseData _data;

        public GameplayStartPhase(GameplayStateMachine stateMachine, GameplayStartPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override void Enter()
        {
            base.Enter();
            StartTimerNextBackboardBonus();
            StartTimerMatch();

            StateMachine.TransitionTo(StateMachine.AimPhase);
        }

        private void StartTimerNextBackboardBonus()
        {
            new BackboardBonusInactiveTimer(_data.BackboardBonus).Start();
            // when its completed will activate the backboard bonus
        }
        private void StartTimerMatch()
        {
            var matchDuration = _data.MatchDuration;
            new MatchTimer(matchDuration).Start();
        }
    }
}
