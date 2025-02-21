using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float timeValue = 10f; // The amount of time to add when this pickup is collected
    public int pointValue = 1;    // The number of points to add when this pickup is collected

    private PickupManager pickupManager;

    void Start()
    {
        pickupManager = FindObjectOfType<PickupManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Use the values defined for this pickup
            pickupManager.OnPickupCollected(timeValue, pointValue);
            Destroy(gameObject);
        }
    }
}