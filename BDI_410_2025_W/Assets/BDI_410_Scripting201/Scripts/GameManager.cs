using UnityEngine;
using UnityEngine.SceneManagement;

namespace EndlessRunner
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            Debug.Log("Game Over!");
            UIManager.Instance.ShowGameOver();
            StartCoroutine(RestartGame());
        }

        private System.Collections.IEnumerator RestartGame()
        {
            yield return new WaitForSecondsRealtime(5);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}