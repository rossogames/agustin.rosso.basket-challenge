using Basket.Score.Modifiers;
using System.Collections.Generic;
using UnityEngine;

namespace Basket.Score.Service
{
    public class ScoreService : IScoreService
    {
        private int _currentShootPoints;
        private int _totalPoints;

        public List<ScoreModifier> _modifiers;

        public ScoreService()
        {
            _modifiers = new List<ScoreModifier>();
        }

        public void SetCurrentShootPoints(int points)
        {
            _currentShootPoints = points;
        }

        public void ApplyPoints()
        {
            var modifiedPoints = GetModifiedPoints();
            _totalPoints += modifiedPoints;

#if UNITY_EDITOR
            Debug.Log($"Points applied: {modifiedPoints}. Total points: {_totalPoints}");
#endif
        }

        public void AddModifier(ScoreModifier modifier)
        {
            _modifiers.Add(modifier);
        }

        public void RemoveModifier(ScoreModifier modifier)
        {
            _modifiers.Remove(modifier);
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
