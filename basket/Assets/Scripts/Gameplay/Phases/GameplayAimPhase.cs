using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Service;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayAimPhase : GameplayBasePhase
    {
        private readonly GameplayAimPhaseData _data;

        public GameplayAimPhase(GameplayStateMachine stateMachine, GameplayAimPhaseData data) : base(stateMachine)
        {
            _data = data;
        }

        public override void OnEventInvoked(AimCompletedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            ThrowBall(eventArg.Target, eventArg.Accuracy);
        }
        public override void OnEventInvoked(MatchTimeEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            StateMachine.TransitionTo(StateMachine.MatchEndPhase);
        }

        private void ThrowBall(ShootingTarget shootingTarget, float accuracy)
        {
            var target = _data.Targets[0];
            _eventService.Raise(new ThrowBallEvent(target.TargetPosition, target.ThrowAngle));
            // TODO: agregar position inicial
            // TODO: posicion de camara
        }
    }
}
