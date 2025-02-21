using UnityEngine;

public class CameraFollow3D : MonoBehaviour
{
    // Public variable to reference the player GameObject
    public Transform player;

    // Public variable for the smoothing factor
    public float smoothSpeed = 0.125f;

    // Public variable for the offset
    public Vector3 offset;

    // Public variables for the threshold distance on the X and Y axes
    public float followThresholdX = 2.0f;
    public float followThresholdY = 2.0f;

    private void LateUpdate()
    {
        // Check if player is not null
        if (player == null)
        {
            // Optional: log a warning or handle the situation accordingly
            Debug.LogWarning("Player object has been destroyed! Muahahahahaha");
            return;
        }

        // Calculate the desired position
        Vector3 desiredPosition = transform.position;

        // Check if player is beyond the threshold distance on the X axis
        if (Mathf.Abs(transform.position.x - player.position.x) > followThresholdX)
        {
            desiredPosition.x = player.position.x + offset.x;
        }

        // Check if player is beyond the threshold distance on the Y axis
        if (Mathf.Abs(transform.position.y - player.position.y) > followThresholdY)
        {
            desiredPosition.y = player.position.y + offset.y;
        }

        // Smoothly move the camera to the desired position using Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Apply the smoothed position to the camera
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z) + offset;
    }
}
