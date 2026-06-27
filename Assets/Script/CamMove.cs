using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float sensitivity;
    float x,y;
    public float upClamp;
    public Transform camRoot;
    public PlayerMovement playerMovement;

    void LateUpdate()
    {
        transform.position = camRoot.position;
    }

    void Update()
    {
        y += Input.GetAxisRaw("MouseY") * sensitivity * Time.deltaTime;
        x += Input.GetAxisRaw("MouseX") * sensitivity * Time.deltaTime;
        y = Mathf.Clamp(y, -90, 60);
        transform.rotation = Quaternion.Euler(-y,x,0);
        playerMovement.rotation += Input.GetAxis("MouseX") * sensitivity * Time.deltaTime;
        playerMovement.transform.rotation = Quaternion.Euler(0, playerMovement.rotation, 0);
    }
}
