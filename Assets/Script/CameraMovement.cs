using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity;
    private float x, y;
    public Transform camRoot;
    public Transform player;

    void Start()
    {
        //Locks the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Sets camera position to player position
        transform.position = camRoot.position;

        // Collects cursor data
        x += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        y -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // vertical rotation gets clamped so your neck doesn't break
        y = Mathf.Clamp(y, -90, 90);

        // Applies the rotation to the camera and player
        transform.rotation = Quaternion.Euler(y, x, 0);
        player.rotation = Quaternion.Euler(0, x, 0);
    }
}
