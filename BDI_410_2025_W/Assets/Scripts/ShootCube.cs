using UnityEngine;

public class ShootCube : MonoBehaviour
{
    // Public prefab of the cube to shoot
    public GameObject cubePrefab;

    // Initial velocity of the cube
    public Vector3 shootVelocity = new Vector3(0, 10, 10);

    // Position to spawn the cube
    public Transform spawnPoint;

    // Time in seconds after which the cube will be destroyed
    public float destroyAfterSeconds = 3.0f;

    void Update()
    {
        // Check if the Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the cube at the spawn point
        GameObject cube = Instantiate(cubePrefab, spawnPoint.position, spawnPoint.rotation);

        // Get the Rigidbody component and set its velocity
        Rigidbody rb = cube.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = shootVelocity;
        }

        // Schedule the cube to be destroyed after the specified time
        Destroy(cube, destroyAfterSeconds);
    }
}
