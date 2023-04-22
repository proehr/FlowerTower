using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using HexGrid;

namespace TowerPlacement
{
    public class DraggableTowerContainer : MonoBehaviour, IBeginDragHandler, IDragHandler, IDroppable, IEndDragHandler
    {
        [SerializeField] private GameObject onDropInstantiationTower;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private Camera sceneCamera;
        [SerializeField] private LayerMask raycastPlacementLayer;
        [SerializeField] private LayerMask uiLayer;

        private Transform _uiParent;
        private bool _isPointerOverGameObject;
        private bool _isSuccessfulDrop;

        private Vector3 _mousePosition;

        private Vector3 GetTransformScreenPoint()
        {
            return uiCamera.WorldToScreenPoint(transform.position);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _isSuccessfulDrop = false;
            _isPointerOverGameObject = true;
            _uiParent = transform.parent;
            _mousePosition = (Vector3)Mouse.current.position.ReadValue() - GetTransformScreenPoint();

            BaseDroppable.ShowDroppablesHighlighting();
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateIsPointerOverUI();

            if (_isPointerOverGameObject)
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

        public void OnEndDrag(PointerEventData eventData)
        {
            BaseDroppable.HideDroppablesHighlighting();
            
            if (!_isSuccessfulDrop)
            {
                AttachToUI();
            }
            else
            {
                Instantiate(onDropInstantiationTower, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        private void UpdateIsPointerOverUI()
        {
            bool isPointerOverGameObject = IsPointerOverUIElement(GetEventSystemRaycastResults());
            if (_isPointerOverGameObject == isPointerOverGameObject) return;

            _isPointerOverGameObject = isPointerOverGameObject;
            if (isPointerOverGameObject)
            {
                OnPointerEnterGameObject();
            }
            else
            {
                OnPointerExitGameObject();
            }
        }

        private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults)
        {
            return eventSystemRaycastResults.Any(curRaycastResult =>
                curRaycastResult.gameObject.layer == uiLayer);
        }

        static List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current)
                { position = Mouse.current.position.ReadValue() };
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raycastResults);
            return raycastResults;
        }

        private void OnPointerEnterGameObject()
        {
            AttachToUI();
        }

        private void AttachToUI()
        {
            Transform bufferTransform;
            (bufferTransform = transform).SetParent(_uiParent);
            bufferTransform.localPosition = Vector3.zero;
            bufferTransform.localRotation = Quaternion.identity;
        }

        private void OnPointerExitGameObject()
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
        }

        private void PlaceOnUI()
        {
            transform.position =
                uiCamera.ScreenToWorldPoint((Vector3)Mouse.current.position.ReadValue() - _mousePosition);
        }

        private void PlaceOnScene()
        {
            if (!HasRaycastOnLayer(out RaycastHit raycastHit)) return;

            transform.position = SnapToHexGrid.ToHexPosition(raycastHit.point);
        }

        private bool HasRaycastOnLayer(out RaycastHit hit)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Ray ray = sceneCamera.ScreenPointToRay(mousePos);
            return Physics.Raycast(ray, out hit, short.MaxValue, raycastPlacementLayer);
        }
    }
}
