using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayAimPhase : GameplayBasePhase
    {
        private readonly GameplayAimPhaseData _data;
        private int _positionIndex = 0;

        public GameplayAimPhase(GameplayStateMachine stateMachine, GameplayAimPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override void Enter()
        {
            base.Enter();
            _positionIndex = 0; // aplicar random
        }

        public override void OnEventInvoked(AimCompletedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            ThrowBall(eventArg.Target, eventArg.AccuracyX, eventArg.AccuracyZ);
        }
        public override void OnEventInvoked(MatchTimeEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            StateMachine.TransitionTo(StateMachine.MatchEndPhase);
        }

        private void ThrowBall(ShootingTarget shootingTarget, float accuracyX, float accuracyZ)
        {
            var aimSetting = _data.Targets[_positionIndex];
            var target = shootingTarget == ShootingTarget.Basket ? aimSetting.BasketTarget : aimSetting.BackboardTarget;

            var targetPosition = new Vector3(
                target.TargetPosition.x * accuracyX,
                target.TargetPosition.y,
                target.TargetPosition.z * accuracyZ
            );

            _eventService.Raise(new ThrowBallEvent(targetPosition, target.ThrowAngle));
            // TODO: agregar position inicial
            // TODO: posicion de camara
        }
    }
}
