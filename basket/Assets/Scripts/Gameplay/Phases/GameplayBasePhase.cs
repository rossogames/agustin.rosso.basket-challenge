using Basket.General;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayBasePhase : IState
    {
        protected readonly IEventService _eventService;

        public GameplayBasePhase()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }

        public virtual void Enter()
        {
            Debug.LogWarning($"Entering {GetType().Name}");
        }

        public virtual void Exit()
        {
            Debug.LogWarning($"Exit {GetType().Name}");
        }

        public virtual void Update()
        {
        }
    }
}
