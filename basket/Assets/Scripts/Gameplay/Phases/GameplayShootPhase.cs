using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;
using System.Threading.Tasks;

namespace Basket.Gameplay.Phases
{
    public class GameplayShootPhase : GameplayBasePhase
    {
        private readonly GameplayShootPhaseData _data;
        private bool _isFirstTargetHitted;
        private bool _isSecondTargetHitted;

        public GameplayShootPhase(GameplayStateMachine stateMachine, GameplayShootPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override async void Enter()
        {
            base.Enter();
            _isFirstTargetHitted = false;
            _isSecondTargetHitted = false;

            await WaitShoot();
        }

        public override void OnEventInvoked(TargetHitEvent eventArg)
        {
            base.OnEventInvoked(eventArg);

            if (eventArg.TriggerIndex == 1)
                _isFirstTargetHitted = true;

            if (eventArg.TriggerIndex == 2)
                _isSecondTargetHitted = true;

            TryApplyPoints();
        }

        private async Task WaitShoot()
        {
            await Task.Delay((int)(_data.WaitTime * 1000));
            StateMachine.TransitionTo(StateMachine.AimPhase);
        }

        private void TryApplyPoints()
        {
            if (_isFirstTargetHitted && _isSecondTargetHitted)
            {
                _scoreService.ApplyPoints();
            }
        }
    }
}
