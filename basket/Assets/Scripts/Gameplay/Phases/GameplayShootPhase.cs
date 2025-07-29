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
        private bool _isMatchEnded;

        public GameplayShootPhase(GameplayStateMachine stateMachine, GameplayShootPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override async void Enter()
        {
            base.Enter();
            _isFirstTargetHitted = false;
            _isSecondTargetHitted = false;
            _isMatchEnded = false;

            await ChangeNextPhase();
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

        public override void OnEventInvoked(MatchTimerEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            _isMatchEnded = true;
        }

        private async Task ChangeNextPhase()
        {
            await Task.Delay((int)(_data.WaitTime * 1000));

            if (_isMatchEnded)
                StateMachine.TransitionTo(StateMachine.MatchEndPhase);
            else
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
