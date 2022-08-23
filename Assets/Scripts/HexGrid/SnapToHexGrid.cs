using System;
using UnityEngine;

namespace HexGrid
{
    [ExecuteInEditMode]
    public class SnapToHexGrid : MonoBehaviour
    {
        private static readonly float INNER_HEIGHT = 2.5f;
        private static readonly float RADIUS = (float) (INNER_HEIGHT * 2 / Math.Sqrt(3));
        private static readonly float X_STEP = RADIUS * 3 / 2;
        private static readonly float Z_STEP = INNER_HEIGHT * 2;

        void Update()
        {
            Vector3 snapPosition;
            var position = transform.position;

            int columnNumber = Mathf.RoundToInt(position.x / X_STEP);
            float zOffset = columnNumber % 2 * INNER_HEIGHT;

            snapPosition.x = columnNumber * X_STEP;
            snapPosition.z = Mathf.RoundToInt((position.z - zOffset) / Z_STEP) * Z_STEP + zOffset;

            position = new Vector3(snapPosition.x, 0f, snapPosition.z);
            transform.position = position;
        }
    }
}