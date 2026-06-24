using UnityEngine;

public class PauseMenu : MonoBehaviour
{
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
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Pause") && paused)
        {
            paused = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
