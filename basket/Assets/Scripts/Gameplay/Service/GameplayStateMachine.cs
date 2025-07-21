using Basket.Gameplay.Phases;
using Basket.General;

namespace Basket.Gameplay.Service
{
    public class GameplayStateMachine : StateMachine<GameplayBasePhase>
    {
        public GameplayCountdownPhase CountdownPhase { get; private set; }
        public GameplayAimPhase AimPhase { get; private set; }
        public GameplayShootPhase ShootPhase { get; private set; }
        public GameplayVictoryPhase VictoryPhase { get; private set; }
        public GameplayDefeatPhase DefeatPhase { get; private set; }

        public GameplayStateMachine(GameplayStateMachineData data)
        {
            CountdownPhase = new GameplayCountdownPhase(data.CountdownPhaseData);
            AimPhase = new GameplayAimPhase();
            ShootPhase = new GameplayShootPhase();
            VictoryPhase = new GameplayVictoryPhase();
            DefeatPhase = new GameplayDefeatPhase();
        }
    }
}
