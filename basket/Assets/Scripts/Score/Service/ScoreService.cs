using Basket.Score.Events;
using Basket.Score.Modifiers;
using Rossoforge.Core.Events;
using Rossoforge.Core.Services;
using Rossoforge.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Basket.Score.Service
{
    public class ScoreService : IScoreService, IInitializable
    {
        private IEventService _eventService;

        private int _currentShootPoints;
        private bool _currentShootIsBackboard;
        private bool _isPerfectShot;

        private int _totalPoints;
        public List<ScoreModifierData> _modifiers;

        public ScoreService()
        {
            _modifiers = new List<ScoreModifierData>();
        }

        public void Initialize()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        public void SetCurrentShootPoints(int points, bool isBackboard, bool isPerfectShot)
        {
            _currentShootPoints = points;
            _currentShootIsBackboard = isBackboard;
            _isPerfectShot = isPerfectShot;
        }

        public void ApplyPoints()
        {
            var modifiedPoints = GetModifiedPoints();
            _totalPoints += modifiedPoints;

            _eventService.Raise(new ScoreChangedEvent(modifiedPoints, _totalPoints, _isPerfectShot));
#if UNITY_EDITOR
            Debug.Log($"Points applied: {modifiedPoints}. Total points: {_totalPoints}");
#endif
        }

        public void AddModifier(ScoreModifierData modifier)
        {
            _modifiers.Add(modifier);
        }

        public void RemoveModifier(ScoreModifierData modifier)
        {
            _modifiers.Remove(modifier);
        }

        public void ResetScore()
        {
            _totalPoints = 0;
        }

        public int GetScore()
        {
            return _totalPoints;
        }

        private int GetModifiedPoints()
        {
            int modifiedPoints = _currentShootPoints;
            if (_modifiers == null)
                return modifiedPoints;

            var modifiersCopy = _modifiers.ToArray();
            foreach (var modifier in modifiersCopy)
            {
                if (modifier.ApplyMode == ScoreModifierApplyMode.Always || _currentShootIsBackboard)
                {
                    modifiedPoints = modifier.ApplyModifier(modifiedPoints);
                    _eventService.Raise(new ScoreModifierAppliedEvent(modifier));
                }
            }

            return modifiedPoints;
        }
    }
}
