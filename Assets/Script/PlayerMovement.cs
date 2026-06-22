using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    // No idea what this does
    private Vector3 moveInput;
        private Vector3 moveDirection;

    // rotation of the player
    float rotation;

    float maxSlopAngle = 45f;

    // Checks if the player is on the ground
    private bool grounded()
    {

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Vector3.down, 1f))
        {
            rb.linearDamping = 5;
            return true;
        }
        rb.linearDamping = 0;
        return false;
    }
    RaycastHit slopeHit;

    [Header("Movement")]
    public float walkingSpeed;
    public float runningSpeed;
    public float jumpForce;


    bool onSlope()
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 1.5f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopAngle && angle != 0;
        }
        return false;
    }

    void Start()
    {
        // Assigns the rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Runs the grounded function
        grounded();
        // Runs the onSlope function
        onSlope();
        // Collects WASD keyboard keys for movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")) * Time.deltaTime;
        rotation += Input.GetAxis("MouseX") * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
        // Calculates direction or smth
        Vector3 direction = transform.right * moveInput.x + transform.forward * moveInput.z;
        if (onSlope())
        {
            moveDirection = Vector3.ProjectOnPlane(direction.normalized, slopeHit.normal).normalized;
            //rb.useGravity = false;
        }
        else
        {
            moveDirection = direction.normalized;
            //rb.useGravity = true;
        }
        if(Input.GetButton("Sprint") && moveInput.magnitude > 0)
        {
            moveDirection = moveDirection * runningSpeed;
        }
        else
        {
            moveDirection = moveDirection * walkingSpeed;
        }

        // Checks if Space is pressed and if you're on the ground
        if (Input.GetButtonDown("Jump") && grounded())
        {
            // Adds force to make the player jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
    void FixedUpdate()
    {
        // Checks if both horizontal and vertical input is zero and if the player is on the ground so you can't air strafe
        if (moveDirection.magnitude > 0 && grounded())
        {
            //rb.AddForce(moveInput, ForceMode.VelocityChange);
            rb.AddForce(moveDirection, ForceMode.VelocityChange);
        }
    }
}
