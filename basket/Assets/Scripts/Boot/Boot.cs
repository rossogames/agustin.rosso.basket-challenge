using Basket.Score.Service;
using Basket.Gameplay.Service;
using Rossoforge.Core.Events;
using Rossoforge.Events.Service;
using Rossoforge.Scenes.Data;
using Rossoforge.Scenes.Service;
using Rossoforge.Services;
using UnityEngine;
using Basket.Timer;

namespace Basket.Boot
{ 
    public class Boot : MonoBehaviour
    {
        [SerializeField]
        private SceneTransitionData _sceneTransitionData;

        [SerializeField]
        private GameplayServiceData _gameplayData;

        private void Awake()
        {
            // Setup
            ServiceLocator.SetLocator(new DefaultServiceLocator());

            var eventService = new EventService();
            var sceneService = new SceneService(eventService, _sceneTransitionData);
            var gameplayService = new GameplayService(_gameplayData);
            var scoreService = new ScoreService();
            var timerService = new TimerService();

            ServiceLocator.Register<IEventService>(eventService);
            ServiceLocator.Register<ISceneService>(sceneService);
            ServiceLocator.Register<IGameplayService>(gameplayService);
            ServiceLocator.Register<IScoreService>(scoreService);
            ServiceLocator.Register<ITimerService>(timerService);
            ServiceLocator.Initialize();

            sceneService.ChangeScene("Main");
        }

    }
}