using UnityEngine;

public class TestButton : MonoBehaviour
{
    public AudioSource audioSource;

    public void Interact()
    {
        audioSource.Play();
    }
}
