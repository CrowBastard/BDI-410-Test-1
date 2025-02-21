using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // The target to follow
    public float distance = 5.0f;
    public float height = 2.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    private void LateUpdate()
    {
        if (!target) return;

        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Dampen the rotation and height
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Set the position of the camera
        Vector3 position = target.position - currentRotation * Vector3.forward * distance;
        position = new Vector3(position.x, currentHeight, position.z);

        // Update the position
        transform.position = position;

        // Always look at the target
        transform.LookAt(target);
    }
}