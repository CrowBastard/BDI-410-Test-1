using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    // Public variables for movement speed and jump force
    public float moveSpeed = 5.0f;
    public float jumpForce = 10.0f;

    // Ground check variables
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    // Private variables
    private Rigidbody rb;
    private bool isGrounded;
    private bool isFacingRight = true;

    void Start()
    {
        // Cache the Rigidbody component for later use
        rb = GetComponent<Rigidbody>();

        // Ensure the Rigidbody has Freeze Rotation constraints set
        rb.constraints = RigidbodyConstraints.FreezeRotationX
                         | RigidbodyConstraints.FreezeRotationY
                         | RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Handle player movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = new Vector3(moveInput * moveSpeed, rb.velocity.y, 0); // Only move on the x and y axes
        rb.velocity = velocity;

        // Handle player flip
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        // Handle jumping
        if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z); // Only apply force on y axis
        }
    }

    void Flip()
    {
        // Switch the way the player is labeled as facing.
        isFacingRight = !isFacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}