using Basket.Timer;
using static Basket.Gameplay.PhasesData.GameplayStartPhaseData;

namespace Basket.Gameplay.Mechanics
{
    public class BackboardBonusInactiveTimer : TimerBase
    {
        private BackboardBonusSettings _backboardBonus;

        public BackboardBonusInactiveTimer(BackboardBonusSettings backboardBonus) : base(backboardBonus.TimeInactive)
        {
            _backboardBonus = backboardBonus;
        }

        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            new BackboardBonusActiveTimer(_backboardBonus).Start();
        }
    }
}
