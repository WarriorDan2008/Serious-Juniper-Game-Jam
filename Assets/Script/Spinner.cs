using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour, IInteractable
{
    public float rotationSpeed = 90f;
    public float rotationTime = 3f;
    private bool isRotating = false;

    public Transform spinner;

    public AudioSource audioSource;

    public void Interact()
    {
        audioSource.Play();
        StartCoroutine(RotateForSeconds(rotationTime));
    }

    IEnumerator RotateForSeconds(float duration)
    {
        isRotating = true;
        float elapsed = 0f;

        while (elapsed < duration)
        { 
            spinner.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); 

            elapsed += Time.deltaTime;
            yield return null;
        }

        isRotating = false;

    }
}
