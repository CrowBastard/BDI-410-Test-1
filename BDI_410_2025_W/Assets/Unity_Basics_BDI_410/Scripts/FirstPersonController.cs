using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonController : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpForce = 300f;
    public float mouseSensitivity = 100.0f;

    private Rigidbody rb;
    private Vector3 moveDirection;
    private float xRotation = 0f;

    public Transform playerCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleMouseLook();
        HandleMovement();
        if (Input.GetButtonDown("Jump"))
        {
            HandleJumping();
        }
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = transform.right * x + transform.forward * z;
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }

    private void HandleJumping()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.1f))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
    }
}