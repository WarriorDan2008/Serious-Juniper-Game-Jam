using DG.Tweening;
using UnityEngine;
public class Billboard : MonoBehaviour
{
    Transform cameraPos;


    void Start()
    {
        cameraPos = GameObject.Find("Main Camera").transform;
    }
    
    void LateUpdate()
    {
        transform.LookAt(cameraPos.position, Vector3.up);
        transform.Rotate(0,-180,0);
    }
}