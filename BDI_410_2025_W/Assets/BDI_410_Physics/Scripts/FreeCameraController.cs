using UnityEngine;

namespace MyUnityPhysicsExperiments
{
    public class FreeCameraController : MonoBehaviour
    {
        public float movementSpeed = 10.0f;
        public float lookSpeed = 2.0f;
        public bool invertY = false;

        private float yaw = 0.0f;
        private float pitch = 0.0f;

        void Update()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            Vector3 movement = new Vector3();

            if (Input.GetKey(KeyCode.W))
                movement += transform.forward;

            if (Input.GetKey(KeyCode.S))
                movement -= transform.forward;

            if (Input.GetKey(KeyCode.A))
                movement -= transform.right;

            if (Input.GetKey(KeyCode.D))
                movement += transform.right;

            if (Input.GetKey(KeyCode.E))
                movement += transform.up;

            if (Input.GetKey(KeyCode.Q))
                movement -= transform.up;

            transform.position += movement * movementSpeed * Time.deltaTime;
        }

        private void HandleRotation()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y") * (invertY ? -1 : 1);

            yaw += mouseX * lookSpeed;
            pitch -= mouseY * lookSpeed;
            pitch = Mathf.Clamp(pitch, -90f, 90f);

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}
