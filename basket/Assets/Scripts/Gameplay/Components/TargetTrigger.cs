using Basket.Gameplay.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components
{
    public class TargetTrigger : MonoBehaviour
    {
        [SerializeField]
        private int targetIndex;

        private IEventService _eventService;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                _eventService.Raise(new TargetHitEvent(targetIndex));
            }
        }
    }
}