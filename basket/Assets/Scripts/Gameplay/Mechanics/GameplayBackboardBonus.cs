using Basket.Gameplay.Service;
using Basket.Score.Modifiers;
using Basket.Score.Service;
using Rossoforge.Services;

namespace Basket.Gameplay.Mechanics
{
    public class GameplayBackboardBonus
    {
        private IScoreService _scoreService;

        BackboardBonusSettings _backboardBonusSettings;
        float _totalWeight = 0f;

        public GameplayBackboardBonus(BackboardBonusSettings backboardBonusSettings)
        {
            _scoreService = ServiceLocator.Get<IScoreService>();

            _backboardBonusSettings = backboardBonusSettings;
            LoadTotalWeight();
        }

        public void TryAddBackboardBonus()
        {
            var randomBonus = GetRandomBackboardBonus();
            _scoreService.AddModifier(randomBonus);
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
