using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Cinemachine;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components.Environment
{
    public class CameraView : MonoBehaviour, IEventListener<AimStartedEvent>
    {
        private IEventService _eventService;

        [SerializeField]
        private CinemachineVirtualCamera _virtualCamera;

        private CinemachineTransposer _transposer;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _transposer = _virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<AimStartedEvent>(this);
        }
        private void OnDisable()
        {
            _eventService.UnregisterListener<AimStartedEvent>(this);
        }

        public void OnEventInvoked(AimStartedEvent eventArg)
        {
            SetCameraOffset(eventArg.CurrentAimSetting, eventArg.CameraDistanceFromBall);
        }

        private void SetCameraOffset(AimSetting aimSetting, float cameraDistanceFromBall)
        {
            var camera = Camera.main;
            var direction = (aimSetting.BallPosition - aimSetting.BasketTarget.TargetPosition);
            direction.y = 0;
            direction.Normalize();

            var offSet = cameraDistanceFromBall * direction;
            offSet.y = 1;

            _transposer.m_FollowOffset = offSet;
        }
    }
}
