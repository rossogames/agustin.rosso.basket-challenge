using Basket.Gameplay.Service;
using Rossoforge.Core.Events;
using Rossoforge.Events.Service;
using Rossoforge.Scenes.Data;
using Rossoforge.Scenes.Service;
using Rossoforge.Services;
using UnityEngine;

namespace Basket.Boot
{ 
    public class Boot : MonoBehaviour
    {
        [SerializeField]
        private SceneTransitionData _sceneTransitionData;

        [SerializeField]
        private GameplayStateMachineData _gameplayStateMachineData;

        private void Awake()
        {
            // Setup
            ServiceLocator.SetLocator(new DefaultServiceLocator());

            var eventService = new EventService();
            var sceneService = new SceneService(eventService, _sceneTransitionData);
            var gameplayService = new GameplayService(_gameplayStateMachineData);

            ServiceLocator.Register<IEventService>(eventService);
            ServiceLocator.Register<ISceneService>(sceneService);
            ServiceLocator.Register<IGameplayService>(gameplayService);
            ServiceLocator.Initialize();

            sceneService.ChangeScene("Game");
        }

    }
}