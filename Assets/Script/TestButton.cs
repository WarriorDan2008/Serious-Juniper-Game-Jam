using UnityEngine;

public class TestButton : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;

    public void Interact()
    {
        audioSource.Play();
    }
}
