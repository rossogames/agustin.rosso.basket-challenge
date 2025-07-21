using Rossoforge.Core.Events;
using Rossoforge.Core.Services;
using Rossoforge.Scenes.Data;
using Rossoforge.Scenes.Events;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rossoforge.Scenes.Service
{
    public class SceneService : ISceneService, IInitializable, IDisposable,
        IEventListener<SceneTransitionActiveEvent>,
        IEventListener<SceneTransitionInactiveEvent>
    {
        private IEventService _eventService;

        private string _previousSceneName;
        private string _nextSceneName;
        private SceneTransitionData _transitionDataDefault;
        private SceneTransitionData _currentTransitionData;

        public string CurrentSceneName => SceneManager.GetActiveScene().name;
        public bool IsLoading { get; private set; }

        public SceneService(IEventService eventService, SceneTransitionData sceneTransitionData)
        {
            _eventService = eventService;
            _transitionDataDefault = sceneTransitionData;
        }
        public void Initialize()
        {
            _eventService.RegisterListener<SceneTransitionActiveEvent>(this);
            _eventService.RegisterListener<SceneTransitionInactiveEvent>(this);
        }
        public void Dispose()
        {
            _eventService.UnregisterListener<SceneTransitionActiveEvent>(this);
            _eventService.UnregisterListener<SceneTransitionInactiveEvent>(this);
        }

        public Task ChangeScene(string sceneName)
        {
            return ChangeScene(sceneName, _transitionDataDefault);
        }
        public async Task ChangeScene(string sceneName, SceneTransitionData sceneTransitionData)
        {
            if (IsLoading)
                return;

            _currentTransitionData = sceneTransitionData;

            _previousSceneName = CurrentSceneName;
            _nextSceneName = sceneName;

            IsLoading = true;

            await LoadSceneAsync(sceneTransitionData.TransitionSceneName, LoadSceneMode.Additive);
        }
        public async Task LoadScene(string sceneName, LoadSceneMode loadSceneMode)
        {
            if (IsLoading)
                return;

            _previousSceneName = CurrentSceneName;
            _nextSceneName = sceneName;

            IsLoading = true;
            await LoadSceneAsync(sceneName, loadSceneMode);
            IsLoading = false;
        }
        public async Task UnloadScene(string sceneName)
        {
            var asyncOp = SceneManager.UnloadSceneAsync(sceneName);
            await AsTask(asyncOp);
        }
        public Task GoBackScene()
        {
            return GoBackScene(_transitionDataDefault);
        }
        public async Task GoBackScene(SceneTransitionData sceneTransitionData)
        {
            if (!string.IsNullOrWhiteSpace(_previousSceneName))
                await ChangeScene(_previousSceneName, sceneTransitionData);
        }
        public Task RestartScene()
        {
            return RestartScene(_transitionDataDefault);
        }
        public Task RestartScene(SceneTransitionData sceneTransitionData)
        {
            return ChangeScene(CurrentSceneName, sceneTransitionData);
        }

        public async void OnEventInvoked(SceneTransitionActiveEvent eventArg)
        {
            await ChangeNextScene();
        }
        public async void OnEventInvoked(SceneTransitionInactiveEvent eventArg)
        {
            await UnloadTransitionScene();
        }

        private async Task ChangeNextScene()
        {
            await UnloadSceneAsync(_previousSceneName);

            if (!string.IsNullOrWhiteSpace(_nextSceneName))
            {
                await LoadSceneAsync(_nextSceneName, LoadSceneMode.Additive);
                //await Awaitable.NextFrameAsync();
            }

            _eventService.Raise<TargetSceneLoadedCompletedEvent>();
        }
        private async Task UnloadTransitionScene()
        {
            await UnloadSceneAsync(_currentTransitionData.TransitionSceneName);
            IsLoading = false;
        }

        private async Task LoadSceneAsync(string sceneName, LoadSceneMode mode)
        {
            var asyncOp = SceneManager.LoadSceneAsync(sceneName, mode);
            if (asyncOp == null)
            {
                Debug.LogError($"Failed to load scene {sceneName}");
                return;
            }

            await AsTask(asyncOp);
        }

        private async Task UnloadSceneAsync(string sceneName)
        {
            var asyncOp = SceneManager.UnloadSceneAsync(sceneName);
            if (asyncOp == null)
            {
                Debug.LogError($"Failed to unload scene {sceneName}");
                return;
            }

            await AsTask(asyncOp);
        }

        public Task AsTask(AsyncOperation asyncOp)
        {
            var tcs = new TaskCompletionSource<object>();
            asyncOp.completed += _ => tcs.SetResult(null);
            return tcs.Task;
        }
    }
}