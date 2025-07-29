using Basket.Score.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Basket.Gameplay.Components.UI
{
    public class ScoreFlyer : MonoBehaviour, IEventListener<ScoreChangedEvent>
    {
        private IEventService _eventService;

        [SerializeField]
        private TextMeshProUGUI _scoreLabel;

        [SerializeField]
        private float _flyDuration = 3f;

        private WaitForSeconds _waitfly;
        private Coroutine _flyCoroutine;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _waitfly = new WaitForSeconds(_flyDuration);
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
            if (_flyCoroutine != null)
                StopCoroutine(_flyCoroutine);

            _flyCoroutine = StartCoroutine(SetScoreText(eventArg.AppliedPoints));
        }

        private IEnumerator SetScoreText(int score)
        {
            _scoreLabel.text = $"+{score} pts";
            yield return _waitfly;
            _scoreLabel.text = string.Empty;
        }
    }
}
