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
            var distance = eventArg.EndScreenPos - eventArg.StartScreenPos;
            Shoot(distance.y);

            StateMachine.TransitionTo(StateMachine.ShootPhase);
        }

        public override void OnEventInvoked(MatchTimerEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            StateMachine.TransitionTo(StateMachine.MatchEndPhase);
        }

        private void StartAim()
        {
            var positionIndex = UnityEngine.Random.Range(0, _data.Targets.Length);
            _currentAimSetting = _data.Targets[positionIndex];

            _eventService.Raise(new AimStartedEvent(_data.AimUiHeight, _data.CameraDistanceFromBall, _currentAimSetting));
        }

        private void Shoot(float shootDistance)
        {
            var shootRelativePosition = shootDistance / _data.AimUiHeight;
            var targetBasketAccuracy = GetShootAcurracy(_currentAimSetting.BasketTarget, shootRelativePosition);
            var targetBackboardAccuracy = GetShootAcurracy(_currentAimSetting.BackboardTarget, shootRelativePosition);

            var missingOffSet = Vector3.zero;
            ShootingTarget shootingTarget;

            bool isBackboardShoot = Math.Abs(targetBackboardAccuracy - 1f) < Math.Abs(targetBasketAccuracy - 1f);
            if (isBackboardShoot)
            {
                shootingTarget = ShootingTarget.Backboard;
                missingOffSet = GetMissOffset(targetBackboardAccuracy);
            }
            else
            {
                shootingTarget = ShootingTarget.Basket;
                missingOffSet = GetMissOffset(targetBasketAccuracy);
            }

            ThrowBall(shootingTarget, missingOffSet);

            int score = targetBasketAccuracy == 1 || targetBackboardAccuracy == 1f ?
                _data.PerfectShotScore :
                _data.DefaultShotScore;

            _scoreService.SetCurrentShootPoints(score, isBackboardShoot);
        }

        private void ThrowBall(ShootingTarget shootingTarget, Vector3 missOffset)
        {
            var target = shootingTarget == ShootingTarget.Basket ?
                _currentAimSetting.BasketTarget :
                _currentAimSetting.BackboardTarget;

            var targetPosition = new Vector3(
                target.TargetPosition.x + missOffset.x,
                target.TargetPosition.y + missOffset.y,
                target.TargetPosition.z + missOffset.z
            );

            _eventService.Raise(new ThrowBallEvent(targetPosition, target.ThrowAngle));
        }

        private float GetShootAcurracy(AimTarget target, float shootRelativePosition)
        {
            float targetMinPosition = target.RelativePositionY - target.RelativeHeigh * 0.5f;
            float targetMaxPosition = target.RelativePositionY + target.RelativeHeigh * 0.5f;

            if (shootRelativePosition >= targetMinPosition && shootRelativePosition <= targetMaxPosition)
                return 1;

            if (shootRelativePosition < targetMinPosition)
                return 1 - (targetMinPosition - shootRelativePosition);

            return 1 - (targetMaxPosition - shootRelativePosition);
        }

        private Vector3 GetMissOffset(float accuracy)
        {
            if (accuracy == 1)
                return new Vector3(0, 0, 0);

            var difference = Math.Min(Math.Abs(1 - accuracy), 0.3f);

            float direction = UnityEngine.Random.Range(0f, 1f) > 0.5f ? 1 : -1;
            float offSetX = _data.MissOffset * difference * direction;

            return new Vector3(offSetX, 0, 0);
        }
    }
}
