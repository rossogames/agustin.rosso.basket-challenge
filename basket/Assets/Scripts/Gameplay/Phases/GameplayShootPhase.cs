using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;
using System.Threading.Tasks;

namespace Basket.Gameplay.Phases
{
    public class GameplayShootPhase : GameplayBasePhase
    {
        private readonly GameplayShootPhaseData _data;

        public GameplayShootPhase(GameplayStateMachine stateMachine, GameplayShootPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override async void Enter()
        {
            base.Enter();
            await WaitShoot();
        }

        public async Task WaitShoot()
        {
            await Task.Delay((int)(_data.WaitTime * 1000)); 
            StateMachine.TransitionTo(StateMachine.AimPhase);
        }
    }
}
