using UnityEngine;
using UnityEngine.UI;

interface IInteractable
{
    public void Interact();
}

public class Interaction : MonoBehaviour
{
    public Image crosshair;
    public Sprite[] crosshairImages;

    public float interactionRange;

    EggSO heldegg;

    public Image HeldImage;

    void Update()
    {
        crosshair.sprite = crosshairImages[0];
        crosshair.rectTransform.sizeDelta = new Vector2(10, 10);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange))
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                crosshair.sprite = crosshairImages[1];
                crosshair.rectTransform.sizeDelta = new Vector2(60, 60);

                if (Input.GetButtonDown("Interact"))
                {
                    hit.transform.TryGetComponent(out IInteractable interactable);
                    interactable.Interact();
                }
            }
        }
    }
}
