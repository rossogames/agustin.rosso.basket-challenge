using Basket.Score.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using TMPro;
using UnityEngine;

namespace Basket.Gameplay.Components.UI
{
    public class ScoreView : MonoBehaviour, IEventListener<ScoreChangedEvent>
    {
        private IEventService _eventService;

        [SerializeField]
        private TextMeshProUGUI _scoreLabel;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<ScoreChangedEvent>(this);
        }
        private void OnDisable()
        {
            _eventService.UnregisterListener<ScoreChangedEvent>(this);
        }

        public void OnEventInvoked(ScoreChangedEvent eventArg)
        {
            SetScoreText(eventArg.TotalPoints);
        }

        private void SetScoreText(int score)
        {
            _scoreLabel.text = score.ToString();
        }
    }
}
