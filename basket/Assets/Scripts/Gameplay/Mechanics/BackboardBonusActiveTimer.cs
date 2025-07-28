using Basket.Gameplay.Service;
using Basket.Score.Events;
using Basket.Score.Modifiers;
using Basket.Score.Service;
using Basket.Timer;
using Rossoforge.Core.Events;
using Rossoforge.Services;

namespace Basket.Gameplay.Mechanics
{
    public class BackboardBonusActiveTimer : TimerBase, IEventListener<ScoreModifierAppliedEvent>
    {
        private IEventService _eventService;
        private IScoreService _scoreService;

        private GameplayServiceData _gameplayServiceData;
        private ScoreModifierBackboardBonus _currentBackboardBonus;

        public BackboardBonusActiveTimer(GameplayServiceData gameplayServiceData) : base(gameplayServiceData.BackboardBonus.TimeActive)
        {
            _gameplayServiceData = gameplayServiceData;

            _eventService = ServiceLocator.Get<IEventService>();
            _scoreService = ServiceLocator.Get<IScoreService>();

            _eventService.RegisterListener<ScoreModifierAppliedEvent>(this);
        }

        public override void Start()
        {
            base.Start();
            TryAddBackboardBonus();
        }

        protected override void OnTimerEnd()
        {
            base.OnTimerEnd();
            TryRemoveBackboardBonus();
            _eventService.UnregisterListener<ScoreModifierAppliedEvent>(this);
        }

        public void OnEventInvoked(ScoreModifierAppliedEvent eventArg)
        {
            if (eventArg.ScoreModifier.Equals(_currentBackboardBonus))
                TryRemoveBackboardBonus();
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
        }

        private ScoreModifierBackboardBonus GetRandomBackboardBonus()
        {
            float totalWeight = LoadTotalWeight();
            var randomValue = UnityEngine.Random.Range(0, totalWeight);

            ScoreModifierBackboardBonus currentBonus = null;
            var currentWeight = 0f;
            foreach (var modifier in _gameplayServiceData.BackboardBonus.Modifiers)
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
            foreach (var modifier in _gameplayServiceData.BackboardBonus.Modifiers)
                totalWeight += modifier.RandomWeight;

            return totalWeight;
        }
    }
}
