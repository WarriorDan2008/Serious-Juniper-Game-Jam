using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panel;
    public CamMove camMove;
    bool paused = false;
    void Awake()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Input.GetButtonDown("Pause") && !paused)
        {
            paused = true;
            Cursor.lockState = CursorLockMode.None;
            panel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Pause") && paused)
        {
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            panel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Sensitivity(float sliderValue)
    {
        camMove.sensitivity = sliderValue;
    }

    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
