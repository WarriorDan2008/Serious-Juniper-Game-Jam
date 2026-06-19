using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public Image crosshair;
    public Sprite[] crosshairImages;

    public float interactionRange;

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
                    hit.transform.GetComponent<TestButton>().Interact();
                }
            }
        }
    }
}
