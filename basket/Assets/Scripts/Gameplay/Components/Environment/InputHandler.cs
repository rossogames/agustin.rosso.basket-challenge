using Basket.Gameplay.PhasesData;
using Basket.Gameplay.Timers;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components.Environment
{
    public class InputHandler : MonoBehaviour, IEventListener<InputDragCanceledEvent>
    {
        [SerializeField]
        private GameplayStartPhaseData _gameplayStartPhaseData;

        private IEventService _eventService;

        private Vector2 _startScreenPos;
        private Vector2 _endScreenPos;
        private bool _isDragging = false;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<InputDragCanceledEvent>(this);
        }
        private void OnDisable()
        {
            _eventService.UnregisterListener<InputDragCanceledEvent>(this);
        }

        public void OnEventInvoked(InputDragCanceledEvent eventArg)
        {
            _isDragging = false;
            _eventService.Raise(new InputDragEndedEvent(_startScreenPos, _endScreenPos));
        }

        private void Update()
        {
            var _previousIsDragging = _isDragging;

            if (Input.touchCount > 0)
                DragTouch();
            else
                DragMouse();

            if (_isDragging)
                _eventService.Raise(new InputDragEvent(_startScreenPos, _endScreenPos));

            if(!_previousIsDragging && _isDragging)
                StartDragTimer();
        }

        private void DragMouse()
        {
            if (!_isDragging && Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
                _startScreenPos = Input.mousePosition;
                _endScreenPos = _startScreenPos;
                return;
            }

            if (Input.GetMouseButton(0) && _isDragging)
            {
                var newScreenPos = Input.mousePosition;
                if (newScreenPos.y > _endScreenPos.y)
                    _endScreenPos = newScreenPos;

                return;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
                _eventService.Raise(new InputDragEndedEvent(_startScreenPos, _endScreenPos));
            }
        }

        private void DragTouch()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _isDragging = true;
                        _startScreenPos = touch.position;
                        _endScreenPos = _startScreenPos;
                        break;

                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        if (_isDragging)
                        {
                            var newScreenPos = touch.position;
                            if (newScreenPos.y > _endScreenPos.y)
                                _endScreenPos = newScreenPos;
                        }
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        _isDragging = false;
                        _eventService.Raise(new InputDragEndedEvent(_startScreenPos, _endScreenPos));
                        break;
                }
            }
        }

        private void StartDragTimer()
        {
            new InputDragTimer(_gameplayStartPhaseData.AimDragDuration).Start();
        }
    }
}
