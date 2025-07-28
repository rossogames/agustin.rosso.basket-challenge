using Basket.Gameplay.Service;
using Basket.Timer;

namespace Basket.Gameplay.Mechanics
{
    public class BackboardBonusInactiveTimer : TimerBase
    {
        private GameplayServiceData _gameplayServiceData;

        public BackboardBonusInactiveTimer(GameplayServiceData gameplayServiceData) : base(gameplayServiceData.BackboardBonus.TimeInactive)
        {
            _gameplayServiceData = gameplayServiceData;
        }

        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            new BackboardBonusActiveTimer(_gameplayServiceData).Start();
        }
    }
}
