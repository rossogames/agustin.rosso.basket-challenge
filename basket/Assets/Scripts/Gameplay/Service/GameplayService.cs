using Rossoforge.Core.Services;

namespace Basket.Gameplay.Service
{
    public class GameplayService : IGameplayService, IInitializable
    {
        private GameplayStateMachineData _data;

        public GameplayStateMachine StateMachine { get; private set; }

        public GameplayService(GameplayStateMachineData data)
        {
            _data = data;
        }

        public void Initialize()
        {
            StateMachine = new GameplayStateMachine(_data);
        }

        public void StartGame()
        {
            StateMachine.StartMachine(StateMachine.CountdownPhase);
        }

        public void Update()
        {
            StateMachine.Update();
        }

        public void EndGame()
        {
            StateMachine.TransitionTo(StateMachine.VictoryPhase);
        }
    }
}
