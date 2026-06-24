using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Spinner : MonoBehaviour, IInteractable
{
    private bool leverPulled = false;
    private bool snap = false;
    public ClockNumber[] clockNumbers;

    public Transform spinner;
    public float spinnerSpeed;
    public AudioSource audioSource;
    private float snappedAngle;
    private ClockNumber landedClockNumber;

    public void Interact()
    {
        if (leverPulled) return;

        audioSource.Play();
        StartCoroutine(SpinTheWheel());
    }

    IEnumerator SpinTheWheel()
    {
        leverPulled = true;
        spinnerSpeed = Random.Range(1800f, 2400f);

        yield return new WaitUntil(() => spinnerSpeed <= 0f);

        snappedAngle = Mathf.Round(spinner.localRotation.eulerAngles.z / 45f) * 45f;
        snap = true;

        yield return new WaitForSeconds(3f);

        foreach (ClockNumber clockNumber in clockNumbers)
        {
            if (snappedAngle == clockNumber.rotation)
            {
                landedClockNumber = clockNumber;
            }
        }

        Debug.Log(landedClockNumber.scene);
        SceneManager.LoadScene(landedClockNumber.scene);
    }

    void Update()
    {
        if (spinnerSpeed > 200f)
        {
            spinnerSpeed -= 500f * Time.deltaTime;
        }
        else if (spinnerSpeed > 100f)
        {
            spinnerSpeed -= 90f * Time.deltaTime;
        }
        else if (spinnerSpeed > 30f)
        {
            spinnerSpeed -= 50f * Time.deltaTime;
        }
        else if (spinnerSpeed > 0f)
        {
            spinnerSpeed -= 30f * Time.deltaTime;
        }
        
        spinner.Rotate(Vector3.forward * spinnerSpeed * Time.deltaTime);

        if (snap)
        {
            spinner.DORotate(new Vector3(0f, 0f, snappedAngle), 0.2f);
        }
    }
}
