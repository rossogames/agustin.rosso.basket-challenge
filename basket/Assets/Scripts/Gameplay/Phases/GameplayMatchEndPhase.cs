using Basket.Gameplay.Service;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayMatchEndPhase : GameplayBasePhase
    {
        public GameplayMatchEndPhase(GameplayStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();
            RaiseGameplayEndedEvent();
        }

        private void RaiseGameplayEndedEvent()
        {
            _eventService.Raise<MatchEndedEvent>();
            // this open the result popup, then rise the GameplayEndedEvent
        }

        public override void OnEventInvoked(GameplayEndedEvent eventArg)
        {
            base.OnEventInvoked(eventArg);
            Debug.LogWarning($"xxxx");
        }
    }
}
