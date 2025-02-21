using System.Collections.Generic;
using UnityEngine;

namespace EndlessRunner
{
    public class EndlessPath : MonoBehaviour
    {


        public GameObject pathPrefab;             // Prefab for path segments
        public GameObject pickupPrefab;           // Prefab for pickups
        public GameObject obstaclePrefab;         // Prefab for obstacles
        public Transform playerTransform;         // Reference to the player
        public int initialSpawnCount = 5;         // Number of initial path segments
        public float pathLength = 30.0f;          // Length of each path segment
        public float safeZone = 20.0f;            // Distance before path segments are removed
        public float pickupObstacleRatio = 0.5f;  // Ratio of pickups to obstacles (0 to 1)

        private List<GameObject> activePaths = new List<GameObject>();
        private List<GameObject> activePickups = new List<GameObject>();
        private List<GameObject> activeObstacles = new List<GameObject>();
        private float spawnZ = 0.0f;
        
        

        void Start()
        {
            if (pathPrefab == null || pickupPrefab == null || obstaclePrefab == null || playerTransform == null)
            {
                Debug.LogError("Missing prefab or player transform assignment.");
                return;
            }

            // Initialize the scene with initial path segments
            for (int i = 0; i < initialSpawnCount; i++)
            {
                SpawnPath(true);
            }
        }

        void Update()
        {
            if (playerTransform.position.z - safeZone > (spawnZ - initialSpawnCount * pathLength))
            {
                SpawnPath(false);
                RemoveOldSegments();
            }
        }

        private void SpawnPath(bool isInitialSpawn)
        {
            GameObject pathSegment = Instantiate(pathPrefab, Vector3.forward * spawnZ, Quaternion.identity);
            activePaths.Add(pathSegment);
            spawnZ += pathLength;

            if (!isInitialSpawn)
            {
                SpawnObjectsOnPath(pathSegment);
            }
        }

        private void RemoveOldSegments()
        {
            if (activePaths.Count > 0)
            {
                Destroy(activePaths[0]);
                activePaths.RemoveAt(0);
            }
        }

        private void SpawnObjectsOnPath(GameObject pathSegment)
        {
            float minX = -5f;
            float maxX = 5f;
            float pathTopY = 0.1f;

            float minZ = 2f;
            float maxZ = pathLength - 2f;

            if (Random.value < pickupObstacleRatio)
            {
                // Spawn Pickup
                float pickupHeight = pickupPrefab.GetComponent<Renderer>().bounds.size.y / 2;
                float pickupY = pathTopY + pickupHeight;
                Vector3 pickupPosition = new Vector3(
                    Random.Range(minX, maxX),
                    pickupY,
                    pathSegment.transform.position.z + Random.Range(minZ, maxZ)
                );

                GameObject pickup = Instantiate(pickupPrefab, pickupPosition, Quaternion.identity);
                activePickups.Add(pickup);
            }
            else
            {
                // Spawn Obstacle
                float obstacleHeight = obstaclePrefab.GetComponent<Renderer>().bounds.size.y / 2;
                float obstacleY = pathTopY + obstacleHeight;
                Vector3 obstaclePosition = new Vector3(
                    Random.Range(minX, maxX),
                    obstacleY,
                    pathSegment.transform.position.z + Random.Range(minZ, maxZ)
                );

                GameObject obstacle = Instantiate(obstaclePrefab, obstaclePosition, Quaternion.identity);
                activeObstacles.Add(obstacle);
            }
        }
    }
}