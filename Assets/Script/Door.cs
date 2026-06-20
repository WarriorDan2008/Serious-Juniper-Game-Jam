using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour, IInteractable
{
    private bool opened = false;
    public void Interact()
    {
        opened = !opened;

        if (opened) { transform.DOLocalRotate(new Vector3(0, -90, 0), 0.6f); }
        else { transform.DOLocalRotate(new Vector3(0, 0, 0), 0.6f); }
    }
}
