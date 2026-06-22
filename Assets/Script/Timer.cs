using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f;
    float curTimer;
    float elapsedTime;
    float elapsedMinuteTimer;
    int minuteAmount;
    int minuteTimer;

    public TMP_Text TimerText;

    void Start()
    {
        curTimer = timeLimit;
        minuteAmount = Mathf.CeilToInt(timeLimit / 60f) - 1;
        minuteTimer = minuteAmount;
    }

    void Update()
    {
        curTimer -= Time.deltaTime;
        elapsedTime += Time.deltaTime;
        elapsedMinuteTimer += Time.deltaTime;
        if(elapsedMinuteTimer >= 60f)
        {
            minuteTimer--;
            elapsedMinuteTimer = 0f;
        }
        TimerText.text = minuteTimer.ToString("00") + ":" + Mathf.FloorToInt(curTimer % 60).ToString("00");
        if (curTimer <= 0f)
        {
            Debug.Log("Time's up!");
            SceneManager.LoadScene(0);
        }
    }
}
