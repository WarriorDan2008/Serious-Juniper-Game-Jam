using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    AudioSource audioSource;
    public float timeLimit = 60f;
    float curTimer;
    float elapsedMinuteTimer;
    int minuteAmount;
    int minuteTimer;
    bool hasplayed = false;

    public TMP_Text TimerText;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        curTimer = timeLimit;
        minuteAmount = Mathf.CeilToInt(timeLimit / 60f) - 1;
        minuteTimer = minuteAmount;
    }

    void Update()
    {
        curTimer -= Time.deltaTime;
        elapsedMinuteTimer += Time.deltaTime;
        if (elapsedMinuteTimer >= 60f)
        {
            minuteTimer--;
            elapsedMinuteTimer = 0f;
        }
        TimerText.text = minuteTimer.ToString("00") + ":" + Mathf.FloorToInt(curTimer % 60).ToString("00");
        if (curTimer <= 0f)
        {
            StartCoroutine(TimeUp());
        }
    }

    IEnumerator TimeUp()
    {
        TimerText.text = "Time is Up!";
        Money.instance.Save();
        if (!hasplayed)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
        hasplayed = true;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(12f);
        SceneManager.LoadScene("Start");
    }
}
