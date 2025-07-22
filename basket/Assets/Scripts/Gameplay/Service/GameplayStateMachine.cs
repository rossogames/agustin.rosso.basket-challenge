using Basket.Gameplay.Phases;
using Basket.General;

namespace Basket.Gameplay.Service
{
    public class GameplayStateMachine : StateMachine<GameplayBasePhase>
    {
        public GameplayLoadPhase LoadPhase { get; private set; }
        public GameplayCountdownPhase CountdownPhase { get; private set; }
        public GameplayAimPhase AimPhase { get; private set; }
        public GameplayShootPhase ShootPhase { get; private set; }
        public GameplayMatchEndPhase MatchEndPhase { get; private set; }

        public GameplayStateMachine(GameplayStateMachineData data)
        {
            LoadPhase = new GameplayLoadPhase(this);
            CountdownPhase = new GameplayCountdownPhase(this, data.CountdownPhaseData);
            AimPhase = new GameplayAimPhase(this);
            ShootPhase = new GameplayShootPhase(this);
            MatchEndPhase = new GameplayMatchEndPhase(this);
        }
    }
}
