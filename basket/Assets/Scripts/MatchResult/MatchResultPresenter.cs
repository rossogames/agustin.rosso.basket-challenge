using Rossoforge.Scenes.Service;
using Rossoforge.Services;

namespace Basket.MatchResult
{
    public class MatchResultPresenter
    {
        private ISceneService _sceneService;

        public MatchResultPresenter()
        {
            _sceneService = ServiceLocator.Get<ISceneService>();
        }

        public void PlayAgain()
        {
            _sceneService.ChangeScene("Gameplay");
        }

        public void ReturnMain()
        {
            _sceneService.ChangeScene("Main");
        }
    }
}
