using UnityEngine;
using UnityEngine.UI;

namespace MyUnityPhysicsExperiments
{
    public class CollisionCounter : MonoBehaviour
    {
        public Text collisionCountText;  // Reference to the UI Text component
        public string countPrefix = "Balls Passed Through: ";
        public int collisionCount = 0;

        private void Start()
        {
            // Initialize the UI Text with the starting collision count
            UpdateCollisionText();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                collisionCount++;
                UpdateCollisionText();
            }
        }

        private void UpdateCollisionText()
        {
            if (collisionCountText != null)
            {
                collisionCountText.text = countPrefix + collisionCount;
            }
            else
            {
                Debug.LogError("CollisionCountText reference not set in the inspector.");
            }
        }
    }
}