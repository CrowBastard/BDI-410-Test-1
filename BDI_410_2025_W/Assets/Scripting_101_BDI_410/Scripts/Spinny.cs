using UnityEngine;

public class Spinny : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // Rotation speed in degrees per second for each axis

    void Update()
    {
        // Rotate the object around its local axes
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}