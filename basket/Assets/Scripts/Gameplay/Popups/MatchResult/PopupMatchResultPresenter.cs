using Basket.Gameplay.Events;
using Rossoforge.Core.Events;
using Rossoforge.Popups.PopupBase;
using Rossoforge.Services;

namespace Basket.Gameplay.Popups.MatchResult
{
    public class PopupMatchResultPresenter : 
        PopupPresenter<PopupMatchResultView, PopupMatchResultPresenter, PopupMatchResultData>
    {
        public PopupMatchResultPresenter(PopupMatchResultView view) 
            : base(ServiceLocator.Get<IEventService>(), view)
        {

        }

        public override void OnDeactivate()
        {
            base.OnDeactivate();
            _eventService.Raise<GameplayEndedEvent>();
        }
    }
}
