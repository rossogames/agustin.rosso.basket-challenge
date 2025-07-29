using Basket.Gameplay.Events;
using Basket.Timer;
using Rossoforge.Core.Events;
using static Basket.Gameplay.PhasesData.GameplayStartPhaseData;

namespace Basket.Gameplay.Timers
{
    public class BackboardBonusInactiveTimer : TimerBase, IEventListener<MatchTimerEndedEvent>
    {
        private BackboardBonusSettings _backboardBonus;
        private bool _isMatchEnded;

        public BackboardBonusInactiveTimer(BackboardBonusSettings backboardBonus) : base(backboardBonus.TimeInactive)
        {
            _backboardBonus = backboardBonus;
        }

        public void OnEventInvoked(MatchTimerEndedEvent eventArg)
        {
            _isMatchEnded = true;
            OnTimerEnd();
        }

        protected override void OnStart()
        {
            base.OnStart();
            _eventService.RegisterListener<MatchTimerEndedEvent>(this);
        }
        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            StartTimerNextBackboardBonus();

            _eventService.UnregisterListener<MatchTimerEndedEvent>(this);
        }

        private void StartTimerNextBackboardBonus()
        {
            if (_isMatchEnded)
                return;

            new BackboardBonusActiveTimer(_backboardBonus).Start();
        }
    }
}
