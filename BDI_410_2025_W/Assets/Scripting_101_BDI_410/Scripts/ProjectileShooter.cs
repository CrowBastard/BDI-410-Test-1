using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign your projectile prefab in the Inspector
    public Transform firePoint;         // Assign a transform that represents the position of the gun barrel or hand
    public float projectileSpeed = 20f; // Speed at which the projectile will be launched
    public float projectileLifetime = 3f; // Time in seconds before the projectile is destroyed
    public bool canFire = true; // Boolean to enable or disable firing

    void Update()
    {
        // Check if firing is enabled and input to fire a projectile is detected
        if (canFire && Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        // Instantiate the projectile at the firePoint position and rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Set the velocity of the projectile in the direction the player is facing
            rb.velocity = firePoint.forward * projectileSpeed;
        }

        // Destroy the projectile after a certain amount of time
        Destroy(projectile, projectileLifetime);
    }
}