using Basket.Gameplay.Phases;
using Basket.General;

namespace Basket.Gameplay.Service
{
    public class GameplayStateMachine : StateMachine<GameplayBasePhase>
    {
        public GameplayStartPhase StartPhase { get; private set; }
        public GameplayAimPhase AimPhase { get; private set; }
        public GameplayShootPhase ShootPhase { get; private set; }
        public GameplayEndsPhase EndsPhase { get; private set; }

        public GameplayStateMachine(GameplayServiceData data)
        {
            StartPhase = new GameplayStartPhase(this, data.StartPhaseData);
            AimPhase = new GameplayAimPhase(this, data.AimPhaseData);
            ShootPhase = new GameplayShootPhase(this, data.ShootPhaseData);
            EndsPhase = new GameplayEndsPhase(this);
        }
    }
}
