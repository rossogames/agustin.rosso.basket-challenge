using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;
using System;
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

        public override void OnEventInvoked(InputDragEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            Debug.LogWarning("SHOOT");

            var distance = eventArg.EndScreenPos - eventArg.StartScreenPos;
            var shootRelativePosition = distance / _data.AimUiHeight;

            var targetBasketAccuracy = GetShootAcurracy(_currentAimSetting.BasketTarget, shootRelativePosition.y);
            var targetBackboardAccuracy = GetShootAcurracy(_currentAimSetting.BackboardTarget, shootRelativePosition.y);

            Debug.LogWarning($"Basket Accuracy: {targetBasketAccuracy}, Backboard Accuracy: {targetBackboardAccuracy}");

            //if()
            //var targetMin = _currentAimSetting.BasketTarget.RelativePositionY - 

            //ThrowBall(eventArg.Target, eventArg.AccuracyX, eventArg.AccuracyZ);
            //StateMachine.TransitionTo(StateMachine.ShootPhase);
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

            _eventService.Raise(new AimStartedEvent(_data.AimUiHeight,_currentAimSetting));
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

        private float GetShootAcurracy(AimTarget target, float shootRelativePosition)
        { 
            float targetMinPosition = target.RelativePositionY - target.RelativeHeigh * 0.5f;
            float targetMaxPosition = target.RelativePositionY + target.RelativeHeigh * 0.5f;

            if (shootRelativePosition >= targetMinPosition && shootRelativePosition <= targetMaxPosition)
                return 1;

            if(shootRelativePosition < targetMinPosition)
                return 1 - (targetMinPosition - shootRelativePosition);

            return 1 - (targetMaxPosition - shootRelativePosition);
        }
    }
}
