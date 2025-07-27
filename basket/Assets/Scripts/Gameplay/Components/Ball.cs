using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour,
        IEventListener<AimStartedEvent>,
        IEventListener<ThrowBallEvent>
    {
        private IEventService _eventService;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<AimStartedEvent>(this);
            _eventService.RegisterListener<ThrowBallEvent>(this);
        }
        private void OnDisable()
        {
            _eventService.UnregisterListener<AimStartedEvent>(this);
            _eventService.UnregisterListener<ThrowBallEvent>(this);
        }

        public void OnEventInvoked(AimStartedEvent eventArg)
        {
            ResetState(eventArg.CurrentAimSetting.BallPosition);
        }
        public void OnEventInvoked(ThrowBallEvent eventArg)
        {
            ThrowBall(_rigidbody, transform.position, eventArg.TargetPosition, eventArg.Angle);
        }

        private void ResetState(Vector3 position)
        {
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
            transform.position = position;
        }

        private void ThrowBall(Rigidbody rb, Vector3 startPos, Vector3 targetPos, float angleDeg)
        {
            float gravity = Mathf.Abs(Physics.gravity.y);
            Vector3 velocity = CalculateLaunchVelocity(startPos, targetPos, angleDeg, gravity);

            if (velocity != Vector3.zero)
            {
                _rigidbody.isKinematic = false;
                rb.velocity = velocity;
            }
        }

        private Vector3 CalculateLaunchVelocity(Vector3 startPos, Vector3 targetPos, float angleDeg, float gravity)
        {
            float angleRad = angleDeg * Mathf.Deg2Rad;

            Vector3 dir = targetPos - startPos;
            float horizontalDist = new Vector2(dir.x, dir.z).magnitude;
            float verticalDist = dir.y;

            float tanAngle = Mathf.Tan(angleRad);
            float cosAngle = Mathf.Cos(angleRad);

            float numerator = gravity * horizontalDist * horizontalDist;
            float denominator = 2 * (horizontalDist * tanAngle - verticalDist) * cosAngle * cosAngle;

            float velocitySquared = numerator / denominator;
            float velocity = Mathf.Sqrt(Mathf.Abs(velocitySquared));

            Vector3 dirXZ = new Vector3(dir.x, 0, dir.z).normalized;

            Vector3 velocityVector = dirXZ * velocity * Mathf.Cos(angleRad) + Vector3.up * velocity * Mathf.Sin(angleRad);
            return velocityVector;
        }
    }
}
