using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayAimPhase : GameplayBasePhase
    {
        private readonly GameplayAimPhaseData _data;
        private AimSetting _currentAimSetting;

        public GameplayAimPhase(GameplayStateMachine stateMachine, GameplayAimPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override void Enter()
        {
            base.Enter();
            StartAim();
        }

        public override void OnEventInvoked(AimCompletedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            ThrowBall(eventArg.Target, eventArg.AccuracyX, eventArg.AccuracyZ);
            StateMachine.TransitionTo(StateMachine.ShootPhase);
        }
        public override void OnEventInvoked(MatchTimeEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            StateMachine.TransitionTo(StateMachine.MatchEndPhase);
        }

        private void StartAim()
        {
            var positionIndex = 0; // aplicar random
            _currentAimSetting = _data.Targets[positionIndex];

            _eventService.Raise(new AimStartedEvent(_currentAimSetting.BallPosition));
        }

        private void ThrowBall(ShootingTarget shootingTarget, float accuracyX, float accuracyZ)
        {
            var target = shootingTarget == ShootingTarget.Basket ? 
                _currentAimSetting.BasketTarget : 
                _currentAimSetting.BackboardTarget;

            var targetPosition = new Vector3(
                target.TargetPosition.x * accuracyX,
                target.TargetPosition.y,
                target.TargetPosition.z * accuracyZ
            );

            _eventService.Raise(new ThrowBallEvent(targetPosition, target.ThrowAngle));
        }
    }
}
