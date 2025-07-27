using Basket.Score.Modifiers;
using System.Collections.Generic;
using UnityEngine;

namespace Basket.Score.Service
{
    public class ScoreService : IScoreService
    {
        private int _currentShootPoints;
        private bool _currentShootIsBackboard;
        private int _totalPoints;
        public List<ScoreModifier> _modifiers;

        public ScoreService()
        {
            _modifiers = new List<ScoreModifier>();
        }

        public void SetCurrentShootPoints(int points, bool isBackboard)
        {
            _currentShootPoints = points;
            _currentShootIsBackboard = isBackboard;
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
                {
                    if (modifier.ApplyMode == ScoreModifierApplyMode.Always || _currentShootIsBackboard)
                        modifiedPoints = modifier.ApplyModifier(modifiedPoints);
                }
            }
            return modifiedPoints;
        }
    }
}
