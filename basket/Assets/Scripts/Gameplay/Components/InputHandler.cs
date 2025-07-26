using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Components
{
    public class InputHandler : MonoBehaviour
    {
        private IEventService _eventService;

        private Vector2 startScreenPos;
        private Vector2 endScreenPos;
        private bool isDragging = false;

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

            if (isDragging)
                _eventService.Raise(new InputDragEvent(startScreenPos, endScreenPos));
        }

        private void DragMouse()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                startScreenPos = Input.mousePosition;
                endScreenPos = startScreenPos;
            }
            else if (Input.GetMouseButton(0) && isDragging)
            {
                endScreenPos = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
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
                        isDragging = true;
                        startScreenPos = touch.position;
                        endScreenPos = startScreenPos;
                        break;

                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        if (isDragging)
                        {
                            endScreenPos = touch.position;
                        }
                        break;

                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        isDragging = false;
                        break;
                }
            }
        }
    }
}
