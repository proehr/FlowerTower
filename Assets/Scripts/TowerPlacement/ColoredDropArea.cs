using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace TowerPlacement
{
    [RequireComponent(typeof(Renderer))]
    public class ColoredDropArea : BaseDropArea
    {
        [SerializeField] private bool isDropArea;
        [SerializeField] private Color hoverColor;

        [Header("Highlightable")] [SerializeField]
        private bool isHighlightable;

        [SerializeField, Tooltip("Only used if highlightable")]
        private Color highlightColor;

        private Renderer _renderer;
        private Color _baseBufferColor;
        private Color _hoverBufferColor;

        protected override void Awake()
        {
            base.Awake();
            _renderer = GetComponent<Renderer>();
            _baseBufferColor = _renderer.material.color;
        }

        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);

            if (_renderer.material.color != _baseBufferColor)
            {
                _renderer.material.color = _baseBufferColor;
            }
        }

        protected override bool IsHighlightable() => isHighlightable;
        protected override bool IsDropArea() => isDropArea;

        protected override void OnPointerDragEnter()
        {
            var material = _renderer.material;
            _hoverBufferColor = material.color;
            material.color = hoverColor;
        }

        protected override void OnPointerDragExit()
        {
            _renderer.material.color = _hoverBufferColor;
        }

        protected override void ShowHighlighting()
        {
            _renderer.material.color = highlightColor;
        }

        protected override void HideHighlighting()
        {
            _renderer.material.color = _baseBufferColor;
        }
    }
}
