using UnityEngine;

namespace Basket.Gameplay.Score
{
    public class ScoreService : IScoreService
    {
        private int _currentShootPoints;
        private int _totalPoints;

        public void SetCurrentShootPoints(int points)
        {
            _currentShootPoints = points;
        }

        public void ApplyPoints()
        {
            _totalPoints += _currentShootPoints;

#if UNITY_EDITOR
            Debug.Log($"Points applied: {_currentShootPoints}. Total points: {_totalPoints}");
#endif
        }
    }
}
