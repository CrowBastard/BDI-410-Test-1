using UnityEngine;

public class SineWaveMovement : MonoBehaviour
{
    // Enum for selecting the movement axis
    public enum Axis { X, Y, Z }
    public Axis movementAxis = Axis.X;

    // Parameters for the sine wave
    public float amplitude = 1.0f; // Amplitude of the sine wave
    public float frequency = 1.0f; // Frequency of the sine wave

    // Initial position of the object
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position based on the sine wave formula
        float sineValue = Mathf.Sin(Time.time * frequency) * amplitude;

        Vector3 newPosition = initialPosition;

        // Apply the sine wave value to the selected axis
        switch (movementAxis)
        {
            case Axis.X:
                newPosition.x += sineValue;
                break;
            case Axis.Y:
                newPosition.y += sineValue;
                break;
            case Axis.Z:
                newPosition.z += sineValue;
                break;
        }

        // Update the object's position
        transform.position = newPosition;
    }
}
