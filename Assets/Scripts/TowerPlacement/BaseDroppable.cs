using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


namespace TowerPlacement
{
    public abstract class BaseDroppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private static readonly List<BaseDroppable> DroppableList = new List<BaseDroppable>();

        protected virtual void Awake()
        {
            DroppableList.Add(this);
        }

        protected virtual void OnDestroy()
        {
            DroppableList.Remove(this);
        }

        public virtual void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent(out IDroppable droppable))
            {
                droppable.OnDrop(IsDroppable());
            }
        }

        protected abstract bool IsDroppable();

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag)
            {
                OnPointerDragEnter();
            }
        }

        protected abstract void OnPointerDragEnter();

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag)
            {
                OnPointerDragExit();
            }
        }

        protected abstract void OnPointerDragExit();

        public static void ShowDroppablesHighlighting()
        {
            foreach (var droppable in DroppableList.Where(droppable => droppable.IsHighlightable()))
            {
                droppable.ShowHighlighting();
            }
        }

        protected abstract bool IsHighlightable();
        protected abstract void ShowHighlighting();

        public static void HideDroppablesHighlighting()
        {
            foreach (var droppable in DroppableList.Where(droppable => droppable.IsHighlightable()))
            {
                droppable.HideHighlighting();
            }
        }

        protected abstract void HideHighlighting();
    }
}
