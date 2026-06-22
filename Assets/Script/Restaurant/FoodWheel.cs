using UnityEngine;
using System.Collections;
using DG.Tweening;


public class FoodWheel : MonoBehaviour
{
    float y;
    public float TransitionSpeed = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.D))
        {
            y += 90f;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            y -= 90f;
        }
        transform.DORotate(new Vector3(15, y, 0), TransitionSpeed);
    }
    
}
