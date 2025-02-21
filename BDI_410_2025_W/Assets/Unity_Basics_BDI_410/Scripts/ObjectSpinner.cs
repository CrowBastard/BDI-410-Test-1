using UnityEngine;

public class ObjectSpinner : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0f, 100f, 0f); // Rotation speed in degrees per second for each axis

    private void Update()
    {
        // Calculate the rotation to apply based on time elapsed and rotation speed
        Vector3 rotation = rotationSpeed * Time.deltaTime;

        // Apply the rotation to the transform
        transform.Rotate(rotation);
    }
}