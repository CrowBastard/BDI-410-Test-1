using UnityEngine;
using UnityEngine.UI;

public class GameOverFall : MonoBehaviour
{
    public Text gameOverText; // Drag and drop the UI Text from the Inspector

    private void Start()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false); // Initially hide the Game Over text
        }
        else
        {
            Debug.LogError("GameOverText is not assigned!");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the player object
            Destroy(collision.gameObject);

            // Display the Game Over text
            if (gameOverText != null)
            {
                gameOverText.gameObject.SetActive(true);
                gameOverText.text = "Game Over";
            }
        }
    }
}
