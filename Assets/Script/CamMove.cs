using UnityEngine;

public class CamMove : MonoBehaviour
{
    float x,y;
    public float upClamp;
    public Transform camRoot;

    void Update()
    {
        transform.position = camRoot.position;
        y += Input.GetAxisRaw("MouseY") * Time.deltaTime;
        x += Input.GetAxisRaw("MouseX") * Time.deltaTime;
        y = Mathf.Clamp(y, -90, 60);
        transform.rotation = Quaternion.Euler(-y,x,0);
    }
}
