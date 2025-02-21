using UnityEngine;

namespace MyUnityPhysicsExperiments
{
    public class SineWaveMovement : MonoBehaviour
    {
        public float speed = 1.0f;
        public float amplitude = 1.0f;
        public Vector3 axis = Vector3.up; // Moving direction

        private Vector3 startPosition;

        void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            float sineWave = Mathf.Sin(Time.time * speed) * amplitude;
            transform.position = startPosition + axis * sineWave;
        }
    }
}