using Basket.Gameplay.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components.Environment
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

                if (targetIndex == 1)
                {
                    Rigidbody rb = other.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.velocity *= 0.1f;
                        rb.AddForce(Vector3.down * 2f, ForceMode.VelocityChange);
                    }
                }
            }
        }
    }
}