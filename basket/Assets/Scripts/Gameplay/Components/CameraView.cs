using Basket.Gameplay.Events;
using Basket.Gameplay.PhasesData;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components
{
    public class CameraView : MonoBehaviour, IEventListener<AimStartedEvent>
    {
        private IEventService _eventService;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
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
            SetCamera(eventArg.CurrentAimSetting, eventArg.CameraDistanceFromBall);
        }

        private void SetCamera(AimSetting aimSetting, float cameraDistanceFromBall)
        {
            var camera = Camera.main;
            var direction = (aimSetting.BallPosition - aimSetting.BasketTarget.TargetPosition).normalized;

            var cameraTargetPosition = aimSetting.BallPosition + cameraDistanceFromBall * direction;
            var cameraTargetViewPosition = new Vector3(
                aimSetting.BasketTarget.TargetPosition.x, 
                camera.transform.position.y,
                aimSetting.BasketTarget.TargetPosition.z
            );

            camera.transform.position = new Vector3(
                    cameraTargetPosition.x,
                    camera.transform.position.y,
                    cameraTargetPosition.z
                );
            
            camera.transform.LookAt(cameraTargetViewPosition);
        }
    }
}
