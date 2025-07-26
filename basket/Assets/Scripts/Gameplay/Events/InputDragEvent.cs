using Rossoforge.Core.Events;
using UnityEngine;

namespace Basket
{
    public struct InputDragEvent : IEvent
    {
        public Vector2 StartScreenPos;
        public Vector2 EndScreenPos;

        public InputDragEvent(Vector2 startScreenPos, Vector2 endScreenPos)
        {
            StartScreenPos = startScreenPos;
            EndScreenPos = endScreenPos;
        }
    }
}
