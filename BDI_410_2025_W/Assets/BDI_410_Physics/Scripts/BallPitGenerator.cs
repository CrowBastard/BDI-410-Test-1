using UnityEngine;

namespace MyUnityPhysicsExperiments
{
    public class BallPitGenerator : MonoBehaviour
    {
        public GameObject ballPrefab;
        public int numberOfBalls = 100;
        public Vector3 area = new Vector3(10, 10, 10);

        private Transform ballParent;

        private void Start()
        {
            // Optional: Create a new parent transform to organize spawned balls in the hierarchy
            ballParent = new GameObject("Balls").transform;
        }

        private void Update()
        {
            // Generate balls when the space bar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GenerateBalls();
            }
        }

        public void GenerateBalls()
        {
            // Clear existing balls
            if (ballParent != null)
            {
                foreach (Transform child in ballParent)
                {
                    Destroy(child.gameObject);
                }
            }

            for (int i = 0; i < numberOfBalls; i++)
            {
                Vector3 offset = new Vector3(
                    Random.Range(-area.x / 2, area.x / 2),
                    Random.Range(-area.y / 2, area.y / 2),
                    Random.Range(-area.z / 2, area.z / 2)
                );

                Vector3 position = transform.position + offset;

                Instantiate(ballPrefab, position, Quaternion.identity, ballParent);
            }
        }
    }
}