using Rossoforge.Core.Events;
using Rossoforge.Scenes;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.General
{
    [RequireComponent(typeof(Animator))]
    public class TransitionFadeInOut : SceneTransition
    {
        private Animator Animator;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            Animator = GetComponent<Animator>();
        }

        override protected void OnTargetSceneLoadedCompletedEvent()
        {
            Animator.SetTrigger("Close");
        }
    }
}