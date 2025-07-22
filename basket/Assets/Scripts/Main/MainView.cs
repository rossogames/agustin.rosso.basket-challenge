using Rossoforge.UI.Buttons;
using UnityEngine;

namespace Basket.Main
{
    public class MainView : MonoBehaviour,
        IButtonClickListener<MainButtonPlay>,
        IButtonClickListener<MainButtonExit>
    {
        public MainPresenter _presenter;

        private void Awake()
        {
            _presenter = new MainPresenter();
        }

        public void OnButtonClickInvoked(MainButtonPlay eventArg)
        {
            _presenter.StartGame();
        }

        public void OnButtonClickInvoked(MainButtonExit eventArg)
        {
            _presenter.ExitGame();
        }
    }
}
