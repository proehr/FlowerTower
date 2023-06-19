using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;


namespace TowerPlacement
{
    public abstract class BaseDropArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        private static readonly List<BaseDropArea> DroppableList = new List<BaseDropArea>();

        private GameObject _droppedItem;

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
            if (!eventData.pointerDrag.TryGetComponent(out IDroppable droppable)) return;
            
            droppable.OnDrop(InternalIsDropArea());

            if (InternalIsDropArea())
            {
                _droppedItem = droppable.ProvideInstantiatedPrefab(transform);
            }
        }

        private bool InternalIsDropArea()
        {
            return _droppedItem == null && IsDropArea();
        }
        
        protected abstract bool IsDropArea();

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag && InternalIsDropArea())
            {
                OnPointerDragEnter();
            }
        }

        protected abstract void OnPointerDragEnter();

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag && InternalIsDropArea())
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
