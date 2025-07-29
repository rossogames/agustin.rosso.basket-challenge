using UnityEngine;

namespace Basket.Gameplay.Service
{
    [CreateAssetMenu(fileName = nameof(GameplayServiceData), menuName = "Basket/Gameplay/ServiceData")]
    public class GameplayServiceData : ScriptableObject
    {
        [field: SerializeField]
        public GameplayStateMachineData StateMachineData { get; private set; }
    }
}
