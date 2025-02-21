using UnityEngine;
using UnityEngine.UI;

namespace EndlessRunner
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        public Text scoreText;
        public Text healthText;
        public Text gameOverText;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void UpdateScore(int score)
        {
            scoreText.text = "Score: " + score;
        }

        public void UpdateHealth(int health)
        {
            healthText.text = "Health: " + health;
        }

        public void ShowGameOver()
        {
            gameOverText.text = "Game Over!";
            StartCoroutine(HideGameOver());
        }

        private System.Collections.IEnumerator HideGameOver()
        {
            yield return new WaitForSecondsRealtime(5);
            gameOverText.text = "Game Over!";
        }
    }
}