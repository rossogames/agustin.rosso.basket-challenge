using Rossoforge.Core.Events;
using Rossoforge.Popups.PopupBase;

namespace Rossoforge.Popups.Events
{
    public readonly struct PopupClosedEvent : IEvent
    {
        public readonly IPopupPresenter PopupPresenter;
        public readonly IPopupView PopupView;

        public PopupClosedEvent(IPopupPresenter popupPresenter, IPopupView popupView)
        {
            PopupPresenter = popupPresenter;
            PopupView = popupView;
        }
    }
}