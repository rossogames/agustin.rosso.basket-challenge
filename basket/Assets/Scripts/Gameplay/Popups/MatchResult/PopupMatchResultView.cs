using Rossoforge.Popups.PopupBase;
using Rossoforge.UI.Buttons;
using TMPro;
using UnityEngine;

namespace Basket.Gameplay.Popups.MatchResult
{
    public class PopupMatchResultView : PopupView<PopupMatchResultView, PopupMatchResultPresenter, PopupMatchResultData>,
        IButtonClickListener<PopupMatchResultButtonOk>
    {
        [SerializeField]
        private TextMeshProUGUI _scoreValueLabel;

        protected override void Awake()
        {
            base.Awake();
            base.Presenter = new PopupMatchResultPresenter(this);
        }

        public void OnButtonClickInvoked(PopupMatchResultButtonOk eventArg)
        {
            Close();
        }

        public void SetScoreText(string text)
        {
            _scoreValueLabel.text = text;
        }
    }
}
