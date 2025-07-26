using Rossoforge.Scenes.Service;
using Rossoforge.Services;
using UnityEditor;

namespace Basket.Main
{
    public class MainPresenter
    {
        private ISceneService _sceneService;   

        public MainPresenter()
        {
            _sceneService = ServiceLocator.Get<ISceneService>();
        }

        public void StartGame()
        {
            _sceneService.ChangeScene("Gameplay");
        }
    }
}
