using UnityEngine;

public class SpinObject : MonoBehaviour
{
    // Public float values for each axis
    public float xSpin = 0.0f;
    public float ySpin = 0.0f;
    public float zSpin = 0.0f;
    public GameObject targetObject;

    // Boolean to toggle spinning
    private bool isSpinning = true;

    void Update()
    {
        // Check for space bar press to toggle spinning
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpinning = !isSpinning;
        }

        // Apply rotation if spinning is enabled and targetObject is set
        if (isSpinning && targetObject != null)
        {
            targetObject.transform.Rotate(xSpin * Time.deltaTime, ySpin * Time.deltaTime, zSpin * Time.deltaTime);
        }
    }
}
