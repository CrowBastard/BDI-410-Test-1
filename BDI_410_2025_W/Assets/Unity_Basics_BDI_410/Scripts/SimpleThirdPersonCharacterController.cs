using UnityEngine;

public class SimpleThirdPersonCharacterController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f; // Rotation speed in degrees per second

    private void Update()
    {
        // Get input for movement and rotation
        float moveVertical = Input.GetAxis("Vertical");
        float rotateHorizontal = Input.GetAxis("Horizontal");

        // Move the character forward and backward
        Vector3 movement = transform.forward * moveVertical * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Rotate the character around the Y-axis
        float rotation = rotateHorizontal * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }
}