using UnityEngine;

namespace MyUnityPhysicsExperiments
{
    public class BallDestroyer : MonoBehaviour
    {
        // This function is called when another collider enters the trigger collider attached to the GameObject where this script is attached
        private void OnTriggerEnter(Collider other)
        {
            // Check if the entering collider has the "Ball" tag
            if (other.CompareTag("Ball"))
            {
                Destroy(other.gameObject);
                Debug.Log("Ball destroyed: " + other.name);
            }
        }
    }
}