using Basket.Gameplay.Events;
using Basket.Score.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket
{
    public class SoundHandler : MonoBehaviour, 
        IEventListener<BackboardHitEvent>,
        IEventListener<ScoreChangedEvent>
    {
        private IEventService _eventService;

        [SerializeField]
        private AudioSource _swooshThroughNet;

        [SerializeField]
        private AudioSource _sourceBackboardHit;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<BackboardHitEvent>(this);
            _eventService.RegisterListener<ScoreChangedEvent>(this);
        }
        private void OnDisable()
        {
            _eventService.UnregisterListener<BackboardHitEvent>(this);
            _eventService.UnregisterListener<ScoreChangedEvent>(this);
        }

        public void OnEventInvoked(BackboardHitEvent eventArg)
        {
            _sourceBackboardHit.Play();
        }

        public void OnEventInvoked(ScoreChangedEvent eventArg)
        {
            _swooshThroughNet.Play();
        }
    }
}
