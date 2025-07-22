using Rossoforge.Core.Events;

namespace Basket.Gameplay.Phases
{
    public class GameplayEndPhase : GameplayBasePhase
    {
        public override void Enter()
        {
            base.Enter();
            RaiseGameplayEndedEvent();
        }
        public override void Exit()
        {
            base.Exit();
        }
        public override void Update()
        {
            base.Update();
        }

        private void RaiseGameplayEndedEvent()
        {
            _eventService.Raise<GameplayEndedEvent>();
        }
    }
}
