using Basket.Gameplay.Phases;
using Basket.General;

namespace Basket.Gameplay.Service
{
    public class GameplayStateMachine : StateMachine<GameplayBasePhase>
    {
        public GameplayIdlePhase IdlePhase { get; private set; }
        public GameplayStartPhase StartPhase { get; private set; }
        public GameplayAimPhase AimPhase { get; private set; }
        public GameplayShootPhase ShootPhase { get; private set; }
        public GameplayMatchEndPhase MatchEndPhase { get; private set; }

        public GameplayStateMachine(GameplayStateMachineData data)
        {
            IdlePhase = new GameplayIdlePhase(this);
            StartPhase = new GameplayStartPhase(this, data.StartPhaseData);
            AimPhase = new GameplayAimPhase(this, data.AimPhaseData);
            ShootPhase = new GameplayShootPhase(this, data.ShootPhaseData);
            MatchEndPhase = new GameplayMatchEndPhase(this);
        }
    }
}
