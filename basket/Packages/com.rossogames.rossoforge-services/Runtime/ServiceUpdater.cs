using UnityEngine;

namespace Rossoforge.Services
{
    public class ServiceUpdater : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            ServiceLocator.Update();
        }
    }
}
