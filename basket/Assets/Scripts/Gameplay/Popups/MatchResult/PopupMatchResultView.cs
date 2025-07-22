using Rossoforge.Popups.PopupBase;

namespace Basket.Gameplay.Popups.MatchResult
{
    public class PopupMatchResultView : PopupView<PopupMatchResultView, PopupMatchResultPresenter, PopupMatchResultData>
    {
        protected override void Awake()
        {
            base.Awake();
            base.Presenter = new PopupMatchResultPresenter(this);
        }
    }
}
