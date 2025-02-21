using UnityEngine;

namespace EndlessRunner
{
    public class PlayerController : MonoBehaviour
    {
        public float forwardSpeed = 5f;   // Speed moving forward
        public float lateralSpeed = 3f;   // Speed for lateral movement
        public Material playerMaterial;
        public Color hitColor = Color.red;
        public int health = 3;            // Player health
        public int score = 0;             // Player score

        private Color originalColor;
        private Rigidbody rb;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody not found on Player.");
                return;
            }

            rb.interpolation = RigidbodyInterpolation.Interpolate;
            originalColor = playerMaterial.color;
            UIManager.Instance.UpdateHealth(health);
            UIManager.Instance.UpdateScore(score); // Initialize UI with starting score
        }

        void FixedUpdate()
        {
            Vector3 forwardMovement = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector3 lateralMovement = Vector3.right * horizontalInput * lateralSpeed * Time.fixedDeltaTime;

            Vector3 movement = forwardMovement + lateralMovement;
            rb.MovePosition(rb.position + movement);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Pickup"))
            {
                score += 10; // Increase score
                Debug.Log("Pickup collected! New score: " + score);
                UIManager.Instance.UpdateScore(score); // Update the score display
                Destroy(other.gameObject); // Destroy the pickup
            }
            if (other.CompareTag("Obstacle"))
            {
                health -= 1; // Decrease health when hitting an obstacle
                Debug.Log("Hit an obstacle! Health: " + health);
                UIManager.Instance.UpdateHealth(health);

                if (health <= 0)
                {
                    GameManager.Instance.GameOver();
                }
                else
                {
                    StartCoroutine(FlashOnHit());
                }
            }
        }

        private System.Collections.IEnumerator FlashOnHit()
        {
            playerMaterial.color = hitColor;
            yield return new WaitForSeconds(0.2f);
            playerMaterial.color = originalColor;
        }
    }
}