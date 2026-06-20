using UnityEngine;
using UnityEngine.AI;
public class Billboard : MonoBehaviour
{
    private Transform cameraPos;

    void Start()
    {
        cameraPos = GameObject.Find("Main Camera").transform;
    }
    
    void Update()
    {
        transform.LookAt(cameraPos);
        transform.Rotate(0, 180, 0);
    }
}