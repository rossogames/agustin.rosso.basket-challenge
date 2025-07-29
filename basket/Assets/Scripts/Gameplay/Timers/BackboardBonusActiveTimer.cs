using Basket.Gameplay.Events;
using Basket.Score.Events;
using Basket.Score.Modifiers;
using Basket.Score.Service;
using Basket.Timer;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using static Basket.Gameplay.PhasesData.GameplayStartPhaseData;

namespace Basket.Gameplay.Timers
{
    public class BackboardBonusActiveTimer : TimerBase, 
        IEventListener<ScoreModifierAppliedEvent>,
        IEventListener<MatchTimerEndedEvent>
    {
        private IScoreService _scoreService;

        private BackboardBonusSettings _backboardBonus;
        private ScoreModifierBackboardBonusData _currentBackboardBonus;
        private bool _isMatchEnded;

        public BackboardBonusActiveTimer(BackboardBonusSettings backboardBonus) : base(backboardBonus.TimeActive)
        {
            _backboardBonus = backboardBonus;
            _scoreService = ServiceLocator.Get<IScoreService>();

            _eventService.RegisterListener<ScoreModifierAppliedEvent>(this);
        }

        protected override void OnStart()
        {
            base.OnStart();
            TryAddBackboardBonus();
            _eventService.RegisterListener<MatchTimerEndedEvent>(this);
        }
        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            TryRemoveBackboardBonus();
            StartTimerWaitForNextBackboardBonus();

            _eventService.UnregisterListener<MatchTimerEndedEvent>(this);
        }

        public void OnEventInvoked(ScoreModifierAppliedEvent eventArg)
        {
            if (eventArg.ScoreModifier.Equals(_currentBackboardBonus))
                OnTimerEnd();
        }
        public void OnEventInvoked(MatchTimerEndedEvent eventArg)
        {
            _isMatchEnded = true;
            OnTimerEnd();
        }

        private void TryAddBackboardBonus()
        {
            _currentBackboardBonus = GetRandomBackboardBonus();
            if (_currentBackboardBonus == null)
                return;

            _scoreService.AddModifier(_currentBackboardBonus);
            _eventService.Raise(new ScoreModifierBackboardBonusAddedEvent(_currentBackboardBonus));
        }

        private void TryRemoveBackboardBonus()
        {
            if (_currentBackboardBonus == null)
                return;

            _scoreService.RemoveModifier(_currentBackboardBonus);
            _eventService.Raise(new ScoreModifierBackboardBonusRemovedEvent(_currentBackboardBonus));

            _eventService.UnregisterListener<ScoreModifierAppliedEvent>(this);
        }

        private ScoreModifierBackboardBonusData GetRandomBackboardBonus()
        {
            float totalWeight = LoadTotalWeight();
            var randomValue = UnityEngine.Random.Range(0, totalWeight);

            ScoreModifierBackboardBonusData currentBonus = null;
            var currentWeight = 0f;
            foreach (var modifier in _backboardBonus.Modifiers)
            {
                if (randomValue < currentWeight + modifier.RandomWeight)
                {
                    currentBonus = modifier;
                    break;
                }

                currentWeight += modifier.RandomWeight;
                currentBonus = modifier;
            }

            return currentBonus;
        }

        private float LoadTotalWeight()
        {
            float totalWeight = 0f;
            foreach (var modifier in _backboardBonus.Modifiers)
                totalWeight += modifier.RandomWeight;

            return totalWeight;
        }

        private void StartTimerWaitForNextBackboardBonus()
        {
            if (_isMatchEnded)
                return;

            new BackboardBonusInactiveTimer(_backboardBonus).Start();
            // when its completed will activate the backboard bonus
        }
    }
}
