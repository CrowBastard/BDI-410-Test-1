using UnityEngine;

namespace MyUnityPhysicsExperiments
{
    public class RandomSpinner : MonoBehaviour
    {
        public float spinSpeed = 10f;

        private Vector3 spinAxis;

        void Start()
        {
            spinAxis = Random.insideUnitSphere.normalized;
        }

        void Update()
        {
            transform.Rotate(spinAxis, spinSpeed * Time.deltaTime);
        }
    }
}