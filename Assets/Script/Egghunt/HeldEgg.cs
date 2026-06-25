using UnityEngine;
using UnityEngine.UI;

public class HeldEgg : MonoBehaviour
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
                    hit.transform.TryGetComponent(out Egg interactable);
                    hit.transform.TryGetComponent(out EggHuntManager interactablee);
                    if (heldegg == null&& interactable !=null)
                    {
                        heldegg = interactable.TakeEgg();
                        HeldImage.sprite = heldegg.eggSprite;
                        HeldImage.color = new Color(255,255,255,255);
                        Debug.Log(heldegg);
                    }
                    if(heldegg != null && interactablee !=null)
                    {
                        interactablee.InsertEgg(heldegg);
                        heldegg = null;
                        HeldImage.color = new Color(0,0,0,0);
                    }

                }
            }
        }
    }
}
