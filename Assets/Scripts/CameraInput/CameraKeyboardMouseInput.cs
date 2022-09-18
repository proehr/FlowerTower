using System;
using Core.Camera;
using Core.Input;
using DataStructures.Events;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityInput = UnityEngine.Input;

namespace TowerDefense.Input
{
    public class CameraKeyboardMouseInput : MonoBehaviour
    {
        public InputEvent onCameraDrag;
        public InputEvent onWheelZoom;

        /// <summary>
        /// Camera rig to control
        /// </summary>
        public CameraRig cameraRig;

        /// <summary>
        /// Pan speed factor when fully zoomed-in
        /// </summary>
        public float nearZoomPanSpeedModifier = 0.2f;

        /// <summary>
        /// Pan speed for RMB panning
        /// </summary>
        public float mouseRmbPanSpeed = 15f;

        /// <summary>
        /// Pan threshold (how near to the edge before we pan. Also the denominator for RMB pan)
        /// </summary>
        public float screenPanThreshold = 40f;

        private void OnEnable()
        {
            onCameraDrag.RegisterListener(DoRightMouseDragPan);
            onWheelZoom.RegisterListener(DoWheelZoom);
        }


        protected float GetPanSpeedForZoomLevel()
        {
            return cameraRig != null ? Mathf.Lerp(nearZoomPanSpeedModifier, 1, cameraRig.CalculateZoomRatio()) : 1.0f;
        }

        protected void DoRightMouseDragPan(InputAction.CallbackContext callbackContext)
        {
            // Calculate zoom ratio
            float zoomRatio = GetPanSpeedForZoomLevel();

            Vector2 panVector = callbackContext.ReadValue<Vector2>();
            panVector = (panVector * Time.deltaTime * mouseRmbPanSpeed * zoomRatio) / screenPanThreshold;

            var camVector = new Vector3(panVector.x, 0, panVector.y);
            cameraRig.PanCamera(camVector);

            cameraRig.StopTracking();
        }

        protected void DoWheelZoom(InputAction.CallbackContext callbackContext)
        {
            float prevZoomDist = cameraRig.zoomDist;
            float zoomValue = callbackContext.ReadValue<float>();
            if (zoomValue != 0)
            {
                cameraRig.ZoomCameraRelative(zoomValue / Math.Abs(zoomValue) * -1);
            }

            // Calculate actual zoom change after clamping
            float zoomChange = cameraRig.zoomDist / prevZoomDist;

            // First get floor position of cursor
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = cameraRig.cachedCamera.ScreenPointToRay(new Vector3(mousePos.x, mousePos.y));

            Vector3 worldPos = Vector3.zero;
            float dist;

            if (cameraRig.floorPlane.Raycast(ray, out dist))
            {
                worldPos = ray.GetPoint(dist);
            }

            // Vector from our current look pos to this point 
            Vector3 offsetValue = worldPos - cameraRig.lookPosition;

            // Pan towards or away from our zoom center
            cameraRig.PanCamera(offsetValue * (1 - zoomChange));
        }
    }
}