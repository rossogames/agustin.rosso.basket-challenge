using TMPro;
using UnityEngine;

namespace Basket.Gameplay.Components
{
    public class Backboard : MonoBehaviour
    {
        [SerializeField]
        private TextMeshPro _pointsLabel;

        private void Awake()
        {
            SetPointText(string.Empty);
        }

        private void SetPointText(string text)
        { 
            _pointsLabel.text = text;
        }
    }
}
