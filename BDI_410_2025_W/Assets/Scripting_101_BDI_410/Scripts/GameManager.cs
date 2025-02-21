using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public AudioSource AudioSource;
    public AudioClip defaultPickupSound;

    public Text timerText;
    public Text scoreText;
    public Text gameOverText;

    private float timeLeft;
    private int score = 0;
    private bool gameIsOver = false;

    public float startTime = 60f;

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

        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        timeLeft = startTime;
        Time.timeScale = 1f; // Ensure normal time
        UpdateUI();
    }

    private void Update()
    {
        if (!gameIsOver)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateUI();
            }
            else
            {
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        gameIsOver = true;
        Time.timeScale = 0f;
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true);
        }

        StartCoroutine(RestartLevelAfterDelay(5f));
    }

    private System.Collections.IEnumerator RestartLevelAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddTimeAndScore(float timeToAdd, int scoreToAdd)
    {
        if (!gameIsOver)
        {
            timeLeft += timeToAdd;
            score += scoreToAdd;
            PlayPickupSound();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.CeilToInt(timeLeft)).ToString();
        scoreText.text = "Score: " + score.ToString();
    }

    private void PlayPickupSound()
    {
        if (defaultPickupSound != null && AudioSource != null)
        {
            AudioSource.PlayOneShot(defaultPickupSound);
        }
        else
        {
            Debug.LogWarning("Pickup sound or AudioSource is missing.");
        }
    }
}