using System.Collections.Generic;
using System.Linq;
using DataStructures.ReactiveVariable;
using DataStructures.RuntimeSets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using HexGrid;

namespace TowerPlacement
{
    public class DraggableTowerContainer : MonoBehaviour, IBeginDragHandler, IDragHandler, IDroppable, IEndDragHandler
    {
        [SerializeField] private GameObject onDropInstantiationTower;
        
        [Header("Kill Requirement")]
        [SerializeField] private GameObjectReactiveRuntimeSet placedTowerReactiveRuntimeSet;
        [SerializeField] private IntReactiveVariable killCount;

        [Header("Drag Relevant")] 
        [SerializeField] private GameObject cardGameObject;
        [SerializeField] private Camera uiCamera;
        [SerializeField, Layer] private int towerDropAreaLayer;
        [SerializeField, Layer] private int uiLayer;

        private Transform _uiParent;
        private bool _isPointerOverUIElement;
        private bool _isSuccessfulDrop;

        private Quaternion _baseRotation;
        private Vector3 _baseScale;
        private Vector3 _mousePosition;

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (placedTowerReactiveRuntimeSet.GetCollection().Count != 0 && !HasEnoughKillsForTower())
            {
                //TODO: implement error message ui
                Debug.LogWarning("Not enough kills!");
                eventData.pointerDrag = null;
                return;
            }

            _baseRotation = transform.localRotation;
            _baseScale = transform.localScale;
            _isSuccessfulDrop = false;
            _isPointerOverUIElement = true;
            _uiParent = transform.parent;
            _mousePosition = (Vector3)Mouse.current.position.ReadValue() - GetTransformScreenPoint();

            BaseDropArea.ShowDroppablesHighlighting();
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateIsPointerOverUI();

            if (_isPointerOverUIElement)
            {
                PlaceOnUI();
            }
            else
            {
                PlaceOnScene();
            }
        }

        public void OnDrop(bool isSuccessfulDrop)
        {
            _isSuccessfulDrop = isSuccessfulDrop;
        }
        
        public GameObject ProvideInstantiatedPrefab()
        {
            return Instantiate(onDropInstantiationTower, transform.position, Quaternion.identity);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            BaseDropArea.HideDroppablesHighlighting();
            
            if (!_isSuccessfulDrop)
            {
                AttachToUI();
            }
            else
            {
                Destroy(gameObject);
                Destroy(cardGameObject);
            }
        }
        
        private bool HasEnoughKillsForTower()
        {
            int totalRequired = 0;
            
            for (int i = 1; i <= placedTowerReactiveRuntimeSet.GetCollection().Count; i++)
            {
                totalRequired += 4 + i * (i + 1);
            }

            return totalRequired <= killCount.GetValue();
        }

        private Vector3 GetTransformScreenPoint()
        {
            return uiCamera.WorldToScreenPoint(transform.position);
        }

        private void UpdateIsPointerOverUI()
        {
            bool isPointerOverUIElement = IsPointerOverUIElement(GetEventSystemRaycastResults());
            
            if (_isPointerOverUIElement == isPointerOverUIElement) return;
            
            _isPointerOverUIElement = isPointerOverUIElement;
            if (isPointerOverUIElement)
            {
                OnPointerEnterUIElement();
            }
            else
            {
                OnPointerExitUIElement();
            }
        }

        private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
        {
            return eventSystemRaycastResults.Any(curRaycastResult =>
                curRaycastResult.gameObject.layer == uiLayer);
        }

        private List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current)
                { position = Mouse.current.position.ReadValue() };
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            return raycastResults;
        }

        private void OnPointerEnterUIElement()
        {
            AttachToUI();
        }

        private void AttachToUI()
        {
            Transform bufferTransform;
            (bufferTransform = transform).SetParent(_uiParent);
            bufferTransform.localPosition = Vector3.zero;
            bufferTransform.localRotation = _baseRotation;
            bufferTransform.localScale = _baseScale;
        }

        private void OnPointerExitUIElement()
        {
            if (transform.parent)
            {
                DetachFromUI();
            }
        }

        private void DetachFromUI()
        {
            Transform bufferTransform = transform;
            bufferTransform.rotation = Quaternion.identity;
            bufferTransform.transform.parent = null;
            bufferTransform.localScale = onDropInstantiationTower.transform.localScale;
        }

        private void PlaceOnUI()
        {
            transform.position =
                uiCamera.ScreenToWorldPoint((Vector3)Mouse.current.position.ReadValue() - _mousePosition);
        }

        private void PlaceOnScene()
        {
            if (!HasRaycastOnLayer(out RaycastResult raycastResult)) return;

            transform.position = SnapToHexGrid.ToHexPosition(raycastResult.worldPosition);
        }

        private bool HasRaycastOnLayer(out RaycastResult hit)
        {
            hit = default;
            List<RaycastResult> raycastResults = GetEventSystemRaycastResults();
            
            foreach (var raycastResult in raycastResults.Where(raycastResult => raycastResult.gameObject.layer == towerDropAreaLayer))
            {
                hit = raycastResult;
                return true;
            }

            return false;
        }
    }
}
