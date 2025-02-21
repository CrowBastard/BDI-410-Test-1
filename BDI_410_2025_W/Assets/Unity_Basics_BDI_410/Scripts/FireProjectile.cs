using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;  // The prefab to be instantiated as the projectile
    public float projectileSpeed = 20f;  // The speed at which the projectile is fired
    public Transform firePoint;          // Point from where the projectile is fired
    public float projectileLifetime = 3f; // Time in seconds before the projectile is destroyed

    [Header("Shooting Controls")]
    public bool canShoot = true;         // If this is true, the object can shoot

    [Header("Camera Reference")]
    public Camera playerCamera;          // The camera from which to get the forward direction

    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null && playerCamera != null)
        {
            // Instantiate the projectile at the FirePoint
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            // Get the Rigidbody component of the instantiated projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            // Ensure the projectile has a Rigidbody
            if (rb != null)
            {
                // Launch the projectile in the direction the camera is facing
                rb.velocity = playerCamera.transform.forward * projectileSpeed;

                // Destroy the projectile after a set lifetime
                Destroy(projectile, projectileLifetime);
            }
            else
            {
                Debug.LogWarning("Projectile prefab does not have a Rigidbody component.");
            }
        }
        else
        {
            Debug.LogWarning("Projectile prefab, fire point, or playerCamera is not set.");
        }
    }
}