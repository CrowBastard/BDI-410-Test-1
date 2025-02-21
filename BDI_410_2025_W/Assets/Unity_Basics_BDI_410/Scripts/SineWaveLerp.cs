using UnityEngine;

public class SineWaveLerp: MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 1.0f;  // How fast the object moves

    private float lerpTime;

    void Update()
    {
        // Increment time by defined speed
        lerpTime += Time.deltaTime * speed;

        // Using sine wave to oscillate the value between 0 and 1
        float value = Mathf.Sin(lerpTime) * 0.5f + 0.5f;

        // Interpolate between two points with calculated sine value
        transform.position = Vector3.Lerp(pointA.position, pointB.position, value);
    }
}