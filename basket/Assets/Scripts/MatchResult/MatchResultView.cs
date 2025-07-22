using Rossoforge.UI.Buttons;
using UnityEngine;

namespace Basket.MatchResult
{
    public class MatchResultView : MonoBehaviour,
        IButtonClickListener<MainButtonPlayAgin>,
        IButtonClickListener<MainButtonReturnMain>
    {
        public MatchResultPresenter _presenter;

        private void Awake()
        {
            _presenter = new MatchResultPresenter();
        }

        public void OnButtonClickInvoked(MainButtonPlayAgin eventArg)
        {
            _presenter.PlayAgain();
        }

        public void OnButtonClickInvoked(MainButtonReturnMain eventArg)
        {
            _presenter.ReturnMain();
        }
    }
}
