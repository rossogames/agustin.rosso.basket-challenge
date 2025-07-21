using Rossoforge.Core.Events;
using Rossoforge.Popups.PopupBase;
using Rossoforge.Services;

namespace Rossoforge.Popups.PopupTemplate
{
    public class PopupTemplatePresenter : PopupPresenter<PopupTemplateView, PopupTemplatePresenter, PopupTemplateData>
    {
        public PopupTemplatePresenter(PopupTemplateView view) 
            : base(ServiceLocator.Get<IEventService>(), view)
        {
        }
    }
}
