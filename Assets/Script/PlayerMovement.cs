using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    // No idea what this does
    private Vector3 moveInput;

    // rotation of the player
    float rotation;

    // Checks if the player is on the ground
    private bool grounded()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f))
        {
            rb.linearDamping = 5;
            return true;
        }
        rb.linearDamping = 0;
        return false;
    }

    [Header("Movement")]
    public float movementSpeed;
    public float runningSpeed;
    public float jumpForce;

    void Start()
    {
        // Assigns the rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Collects WASD keyboard keys for movement
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        rotation += Input.GetAxis("MouseX") * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rotation, 0);
        
        // Calculates direction or smth
        Vector3 direction = transform.right * x + transform.forward * z;
        moveInput = direction.normalized;

        // Runs the grounded function
        grounded();

        // Checks if Space is pressed and if you're on the ground
        if (Input.GetButtonDown("Jump") && grounded())
        {
            // Adds force to make the player jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
    }

    void FixedUpdate()
    {
        // Checks if both horizontal and vertical input is zero and if the player is on the ground so you can't air strafe
        if (moveInput.magnitude > 0 && grounded())
        {
            // --- The commented code features more snappier movement, comment the current code and uncomment the commented code for snappier movement ---

            // Vector3 velocity = new Vector3(moveInput.x, rb.linearVelocity.y, moveInput.z);

            if (Input.GetButton("Run"))
            {
                rb.AddForce(moveInput * runningSpeed, ForceMode.VelocityChange);
                //rb.linearVelocity = velocity * runningSpeed;
            }
            else
            {
                rb.AddForce(moveInput * movementSpeed, ForceMode.VelocityChange);
                //rb.linearVelocity = velocity * movementSpeed;
            }
        }
        //else
        //{
            //rb.linearVelocity = new Vector3(0, rb.linearVelocity.y, 0);
        //}
    }
}
