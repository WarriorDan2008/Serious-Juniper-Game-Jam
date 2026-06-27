using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class Spinner : MonoBehaviour, IInteractable
{
    public ClockNumber[] clockNumbers;
    public Transform SpinnerArrow;
    int extraSpins = 3;
    public float spinDuration = 3f;
    public AnimationCurve easeCurve;

    private bool isSpinning = false;
    private float currentAngle = 0f;

    public void Interact()
    {
        switch (PlayerPrefs.GetInt("WheelSpunAmount"))
        {
            case 0:
                SpinToTarget(1);
                break;
            case 1:
                SpinToTarget(2);
                break;
            case 2:
                SpinToTarget(3);
                break;
            case 3:
                SpinToTarget(4);
                break;
            case 4:
                SpinToTarget(6);
                break;
            case 5:
                SpinToTarget(7);
                break;
            case 6:
                SpinToTarget(8);
                break;
            case 7:
                SpinToTarget(9);
                break;
            case 8:
                SpinToTarget(11);
                break;
            case 9:
                ClockNumber clocknum12 = clockNumbers[11];
                if (PlayerPrefs.GetFloat("Cash") > 1000f)
                {

                    clocknum12.scene = "SceneTrueEnding";
                }
                else
                {
                    clocknum12.scene = "ProLogue";
                }
                SpinToTarget(12);
                break;
        }
    }
    public void SpinToTarget(int targetSlice)
    {
        if (isSpinning) return;
        StartCoroutine(SpinRoutine(targetSlice));
    }

    private IEnumerator SpinRoutine(int targetSlice)
    {
        ClockNumber targetclocknum = clockNumbers[targetSlice - 1];
        isSpinning = true;
        float targetAngle = -targetclocknum.rotation;
        float totalSpinAmount = (360f * extraSpins) + targetAngle;
        float endAngle = currentAngle - totalSpinAmount;
        float elapsedTime = 0f;
        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;
            float curveValue = easeCurve.Evaluate(t);
            float newAngle = Mathf.Lerp(currentAngle, endAngle, curveValue);
            SpinnerArrow.eulerAngles = new Vector3(0, 0, newAngle);
            yield return null;
        }
        currentAngle = endAngle % 360f;
        SpinnerArrow.eulerAngles = new Vector3(0, 0, currentAngle);
        isSpinning = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(targetclocknum.scene);
        int curspinamount = PlayerPrefs.GetInt("WheelSpunAmount");
        PlayerPrefs.SetInt("WheelSpunAmount", curspinamount + 1);
    }
}