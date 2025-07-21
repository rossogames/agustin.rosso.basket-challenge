using Rossoforge.Popups.PopupBase;

namespace Rossoforge.Popups.PopupTemplate
{
    public class PopupTemplateView : PopupView<PopupTemplateView, PopupTemplatePresenter, PopupTemplateData>
    {
        private void Start()
        {
            base.Presenter = new PopupTemplatePresenter(this);
        }
    }
}
