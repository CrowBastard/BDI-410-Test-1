using UnityEngine;

[System.Serializable]
public class SpawnableObject
{
    public GameObject prefab; // The prefab to be spawned
    public float spawnProbability; // The probability of spawning this prefab
}

public class RandomSpawner : MonoBehaviour
{
    public SpawnableObject[] spawnableObjects; // Array of spawnable objects

    private void Start()
    {
        SpawnRandomObject();
    }

    private void SpawnRandomObject()
    {
        float totalProbability = 0f;

        // Calculate the total probability
        foreach (SpawnableObject obj in spawnableObjects)
        {
            totalProbability += obj.spawnProbability;
        }

        if (totalProbability <= 0)
        {
            Debug.LogError("Total probability must be greater than zero.");
            return;
        }

        // Generate a random value between 0 and totalProbability
        float randomValue = Random.Range(0, totalProbability);

        // Determine which object to spawn based on randomValue
        float cumulativeProbability = 0f;
        foreach (SpawnableObject obj in spawnableObjects)
        {
            cumulativeProbability += obj.spawnProbability;
            if (randomValue < cumulativeProbability)
            {
                // Instantiate the selected prefab
                if (obj.prefab != null)
                {
                    Instantiate(obj.prefab, transform.position, Quaternion.identity);
                    Debug.Log("Spawned: " + obj.prefab.name);
                }
                else
                {
                    Debug.LogWarning("Prefab is null for one of the spawnable objects.");
                }
                break;
            }
        }
    }
}