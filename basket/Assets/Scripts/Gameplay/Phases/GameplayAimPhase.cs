using Basket.Gameplay.Events;
using Basket.Gameplay.Service;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayAimPhase : GameplayBasePhase
    {
        public GameplayAimPhase(GameplayStateMachine stateMachine) : base(stateMachine)
        {
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

        private void ThrowBall(ShootingTarget target, float accuracy)
        {
            var targetPosition = new Vector3(-11.4f, 2.5f, 0); 
            _eventService.Raise(new ThrowBallEvent(targetPosition, 60));
        }
    }
}
