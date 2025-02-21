using UnityEngine;

public class PickupManager : MonoBehaviour
{
    public GameObject pickupPrefab;
    public BoxCollider spawnArea;   // Define the spawn area using a BoxCollider
    public LayerMask avoidLayers;   // Layers to avoid when spawning a pickup
    public float minSpawnDistance = 2f;  // Minimum distance from other objects
    public int maxSpawnAttempts = 10;
    public GameManager gameManager; // Make sure this is declared and assigned properly

    private GameObject currentPickup;

    void Start()
    {
        SpawnPickup();
    }

    void SpawnPickup()
    {
        if (currentPickup != null) Destroy(currentPickup);

        for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
        {
            Vector3 spawnPosition = GetRandomPositionInSpawnArea();

            if (IsValidSpawnPosition(spawnPosition))
            {
                currentPickup = Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
                return;
            }
        }

        Debug.LogWarning("No valid spawn position found after max attempts.");
    }

    Vector3 GetRandomPositionInSpawnArea()
    {
        Bounds bounds = spawnArea.bounds;
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            bounds.center.y, // Assuming Y remains constant for flat surfaces
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    bool IsValidSpawnPosition(Vector3 position)
    {
        Collider[] hitColliders = Physics.OverlapSphere(position, minSpawnDistance, avoidLayers);
        return hitColliders.Length == 0;
    }

    public void OnPickupCollected(float timeValue, int pointValue)
    {
        if (gameManager != null)
        {
            gameManager.AddTimeAndScore(timeValue, pointValue);
            SpawnPickup();
        }
        else
        {
            Debug.LogError("GameManager reference is missing in PickupManager.");
        }
    }
}