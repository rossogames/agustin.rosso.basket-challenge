using Rossoforge.Core.Events;
using Rossoforge.Events.Service;
using Rossoforge.Services;
using UnityEngine;

namespace Rossoforge.Popups.PopupDemo
{
    public class Boot : MonoBehaviour
    {
        private void Awake()
        {
            // Setup
            ServiceLocator.SetLocator(new DefaultServiceLocator());
            ServiceLocator.Register<IEventService>(new EventService());

            ServiceLocator.Initialize();
        }

    }
}