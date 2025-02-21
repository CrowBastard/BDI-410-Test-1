using UnityEngine;

namespace EndlessRunner
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform playerTransform; // Reference to the player's transform
        public Vector3 offset; // Offset from the player

        [Range(0, 1)]
        public float smoothSpeed = 0.125f; // Smoothing factor

        private void LateUpdate()
        {
            if (playerTransform == null)
            {
                Debug.LogWarning("Player transform not assigned.");
                return;
            }

            // Calculate the desired position with the offset
            Vector3 desiredPosition = playerTransform.position + offset;
            // Smoothly interpolate between current and desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update the camera position
            transform.position = smoothedPosition;
        }
    }
}