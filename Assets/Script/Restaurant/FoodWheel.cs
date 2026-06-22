using UnityEngine;

public class FoodWheel : MonoBehaviour
{
    public float rotationAngle = 90f;
    public float rotationSpeed = 5f;

    public KeyCode rotateKey = KeyCode.R;
    private Quaternion targetRotation;

    private bool isRotating = false;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRotation = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rotateKey) && !isRotating)
        {
            targetRotation *= Quaternion.Euler(rotationAxis * rotationAngle);
            isRotating = true;
        }

        if (isRotating)
        {
            transform.rotation = Quarternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (Quaternion.Angle(transform.rotation, targetRotation) <0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }
}
