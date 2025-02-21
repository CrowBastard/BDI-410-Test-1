using UnityEngine;

namespace EndlessRunner
{
    public class Pickup : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                // Get a reference to the PlayerController component
                PlayerController playerController = other.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    // Update the score
                    playerController.score += 10; // Increase score directly
                    UIManager.Instance.UpdateScore(playerController.score); // Update UI
                }

                // Destroy the pickup after it is collected
                Destroy(gameObject);
            }
        }
    }
}