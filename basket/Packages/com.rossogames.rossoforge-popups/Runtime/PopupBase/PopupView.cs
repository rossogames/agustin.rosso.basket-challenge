using Rossoforge.Popups.Components;
using Rossoforge.UI.Buttons;
using UnityEngine;

namespace Rossoforge.Popups.PopupBase
{
    [RequireComponent(typeof(PopupController))]
    public abstract class PopupView<V, P, D> : MonoBehaviour, IPopupView,
        IButtonClickListener<PopupButtonClose>
        where V : PopupView<V, P, D>
        where P : PopupPresenter<V, P, D>
        where D : IPopupData
    {
        private PopupController _popupController;

        protected P Presenter { get; set; }
        public PopupState State => _popupController.State;

        protected virtual void Awake()
        {
            _popupController = GetComponent<PopupController>();
        }

        public void SetData(IPopupData popupData) => Presenter.OnSetData((D)popupData);
        public void Close() => _popupController.Close();
        public void Open() => _popupController.Open();
        public bool CanBeOpened() => State == PopupState.Inactive;
        public bool CanBeClosed() => State == PopupState.Active;

        public virtual void OnOpening() => Presenter.OnShowing();
        public virtual void OnActivate() => Presenter.OnActivate();
        public virtual void OnClosing() => Presenter.OnHiding();
        public virtual void OnDeactivate() => Presenter.OnDeactivate();

        public virtual void OnButtonClickInvoked(PopupButtonClose eventArg) => Close();
    }
}
