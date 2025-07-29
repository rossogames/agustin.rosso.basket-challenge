using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components.Environment
{
    public class InputHandler : MonoBehaviour
    {
        private IEventService _eventService;

        private Vector2 _startScreenPos;
        private Vector2 _endScreenPos;
        private bool _isDragging = false;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        private void Update()
        {
            if (Input.touchCount > 0)
                DragTouch();
            else
                DragMouse();

            if (_isDragging)
                _eventService.Raise(new InputDragEvent(_startScreenPos, _endScreenPos));
        }

        private void DragMouse()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isDragging = true;
                _startScreenPos = Input.mousePosition;
                _endScreenPos = _startScreenPos;
            }
            else if (Input.GetMouseButton(0) && _isDragging)
            {
                _endScreenPos = Input.mousePosition;
                if (_endScreenPos.y < _startScreenPos.y)
                    _endScreenPos.y = _startScreenPos.y;
            }
            else if (Input.GetMouseButtonUp(0))
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
                            _endScreenPos = touch.position;
                            if (_endScreenPos.y < _startScreenPos.y)
                                _endScreenPos.y = _startScreenPos.y;
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
    }
}
