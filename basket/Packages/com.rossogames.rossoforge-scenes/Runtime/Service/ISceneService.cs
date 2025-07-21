using Rossoforge.Core.Services;
using Rossoforge.Scenes.Data;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Rossoforge.Scenes.Service
{
    public interface ISceneService : IService
    {
        bool IsLoading { get; }
        string CurrentSceneName { get; }
        Task ChangeScene(string sceneName);
        Task ChangeScene(string sceneName, SceneTransitionData sceneTransitionData);
        Task LoadScene(string sceneName, LoadSceneMode loadSceneMode);
        Task UnloadScene(string sceneName);
        Task GoBackScene();
        Task GoBackScene(SceneTransitionData sceneTransitionData);
        Task RestartScene();
        Task RestartScene(SceneTransitionData sceneTransitionData);
    }
}