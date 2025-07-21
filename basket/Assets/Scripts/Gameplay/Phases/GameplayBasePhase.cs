using Basket.General;
using UnityEngine;

namespace Basket.Gameplay.Phases
{
    public class GameplayBasePhase : IState
    {
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
            Debug.LogWarning($"Update {GetType().Name}");
        }
    }
}
