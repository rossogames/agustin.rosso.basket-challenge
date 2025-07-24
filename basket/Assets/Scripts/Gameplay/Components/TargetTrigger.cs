using UnityEngine;

namespace Basket.Gameplay.Components
{
    public class TargetTrigger : MonoBehaviour
    {
        [SerializeField]
        private int targetIndex;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                Debug.LogWarning($"test {targetIndex}");
            }
        }
    }
}