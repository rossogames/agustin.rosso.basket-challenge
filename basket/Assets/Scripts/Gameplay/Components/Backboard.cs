using Basket.Score.Events;
using Rossoforge.Core.Events;
using Rossoforge.Services;
using TMPro;
using UnityEngine;

namespace Basket.Gameplay.Components
{
    public class Backboard : MonoBehaviour, 
        IEventListener<ScoreModifierBackboardBonusAppliedEvent>,
        IEventListener<ScoreModifierBackboardBonusRemovedEvent>
    {
        [SerializeField]
        private TextMeshPro _pointsLabel;

        [SerializeField]
        private MeshRenderer _backboardMeshRenderer;

        [SerializeField]
        private Material _highlightMaterial;

        private IEventService _eventService;
        private Material _defaultMaterial;

        private void Awake()
        {
            _eventService = ServiceLocator.Get<IEventService>();

            _defaultMaterial = _backboardMeshRenderer.materials[1];
            HighlightScore(string.Empty, _defaultMaterial);
        }

        private void OnEnable()
        {
            _eventService.RegisterListener<ScoreModifierBackboardBonusAppliedEvent>(this);
            _eventService.RegisterListener<ScoreModifierBackboardBonusRemovedEvent>(this);
        }

        private void OnDisable()
        {
            _eventService.UnregisterListener<ScoreModifierBackboardBonusAppliedEvent>(this);
            _eventService.UnregisterListener<ScoreModifierBackboardBonusRemovedEvent>(this);
        }

        public void OnEventInvoked(ScoreModifierBackboardBonusAppliedEvent eventArg)
        {
            HighlightScore(eventArg.ScoreModifier.DisplayValue, _highlightMaterial);
        }
        public void OnEventInvoked(ScoreModifierBackboardBonusRemovedEvent eventArg)
        {
            HighlightScore(string.Empty, _defaultMaterial);
        }

        private void HighlightScore(string text, Material material)
        {
            var materials = _backboardMeshRenderer.materials;
            materials[1] = material;
            _backboardMeshRenderer.materials = materials;

            _pointsLabel.text = text;
        }
    }
}
