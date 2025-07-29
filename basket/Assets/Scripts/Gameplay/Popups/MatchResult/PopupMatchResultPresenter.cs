using Basket.Gameplay.Events;
using Basket.Score.Service;
using Rossoforge.Core.Events;
using Rossoforge.Popups.PopupBase;
using Rossoforge.Services;

namespace Basket.Gameplay.Popups.MatchResult
{
    public class PopupMatchResultPresenter :
        PopupPresenter<PopupMatchResultView, PopupMatchResultPresenter, PopupMatchResultData>
    {
        private IScoreService _scoreService;

        public PopupMatchResultPresenter(PopupMatchResultView view)
            : base(ServiceLocator.Get<IEventService>(), view)
        {
            _scoreService = ServiceLocator.Get<IScoreService>();
        }

        public override void OnShowing()
        {
            base.OnShowing();
            SetScore();
        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            _eventService.Raise<PopupMatchResultClosedEvent>();
        }

        private void SetScore()
        {
            var score = _scoreService.GetScore();
            View.SetScoreText(score.ToString());
        }
    }
}
