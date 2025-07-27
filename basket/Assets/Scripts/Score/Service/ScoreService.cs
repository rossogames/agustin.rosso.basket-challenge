using Basket.Score.Modifiers;
using UnityEngine;

namespace Basket.Score.Service
{
    public class ScoreService : IScoreService
    {
        private int _currentShootPoints;
        private int _totalPoints;

        public ScoreModifier[] _modifiers;

        public void SetCurrentShootPoints(int points)
        {
            _currentShootPoints = points;
        }

        public void ApplyPoints()
        {
            var modifiedPoints = GetModifiedPoints();
            _totalPoints += modifiedPoints;

#if UNITY_EDITOR
            Debug.Log($"Points applied: {_currentShootPoints}. Total points: {_totalPoints}");
#endif
        }

        private int GetModifiedPoints()
        {
            int modifiedPoints = _currentShootPoints;
            if (_modifiers != null)
            {
                foreach (var modifier in _modifiers)
                    modifiedPoints = modifier.ApplyModifier(modifiedPoints);
            }
            return modifiedPoints;
        }
    }
}
