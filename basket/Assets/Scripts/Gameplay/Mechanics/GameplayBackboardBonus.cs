using Basket.Gameplay.Service;
using Basket.Score.Events;
using Basket.Score.Modifiers;
using Basket.Score.Service;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using System;

namespace Basket.Gameplay.Mechanics
{
    public class GameplayBackboardBonus : IDisposable,
        IEventListener<ScoreModifierAppliedEvent>
    {
        private IScoreService _scoreService;
        private IEventService _eventService;

        private BackboardBonusSettings _backboardBonusSettings;
        private ScoreModifierBackboardBonus _currentBackboardBonus;
        private float _totalWeight = 0f;

        public GameplayBackboardBonus(BackboardBonusSettings backboardBonusSettings)
        {
            _scoreService = ServiceLocator.Get<IScoreService>();
            _eventService = ServiceLocator.Get<IEventService>();

            _backboardBonusSettings = backboardBonusSettings;
            LoadTotalWeight();

            _eventService.RegisterListener<ScoreModifierAppliedEvent>(this);
        }

        public void Dispose()
        {
            _eventService.UnregisterListener<ScoreModifierAppliedEvent>(this);
        }

        public void OnEventInvoked(ScoreModifierAppliedEvent eventArg)
        {
            if (eventArg.ScoreModifier.Equals(_currentBackboardBonus))
                TryRemoveBackboardBonus();
        }

        public void TryAddBackboardBonus()
        {
            _currentBackboardBonus = GetRandomBackboardBonus();
            if (_currentBackboardBonus == null)
                return;

            _scoreService.AddModifier(_currentBackboardBonus);
            _eventService.Raise(new ScoreModifierBackboardBonusAddedEvent(_currentBackboardBonus));
        }

        public void TryRemoveBackboardBonus()
        {
            if (_currentBackboardBonus == null)
                return;

            _scoreService.RemoveModifier(_currentBackboardBonus);
            _eventService.Raise(new ScoreModifierBackboardBonusRemovedEvent(_currentBackboardBonus));
        }

        private ScoreModifierBackboardBonus GetRandomBackboardBonus()
        {
            var randomValue = UnityEngine.Random.Range(0, _totalWeight);

            ScoreModifierBackboardBonus currentBonus = null;
            var currentWeight = 0f;
            foreach (var modifier in _backboardBonusSettings.Modifiers)
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

        private void LoadTotalWeight()
        {
            _totalWeight = 0f;
            foreach (var modifier in _backboardBonusSettings.Modifiers)
                _totalWeight += modifier.RandomWeight;
        }
    }
}
