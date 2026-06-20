using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 90f;
    public float rotationTime = 3f;

    private bool isRotating = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
         StartCoroutine(RotateForSeconds(rotationTime));

        }

    }

    IEnumerator RotateForSeconds(float duration)
    {
        isRotating = true;
        float elapsed = 0f;

        while (elapsed < duration)
        { 
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); 

            elapsed += Time.deltaTime;
            yield return null;
        }

        isRotating = false;

    }
}
