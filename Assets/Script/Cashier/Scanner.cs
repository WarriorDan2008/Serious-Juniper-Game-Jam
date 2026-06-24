using UnityEngine;

public class Scanner : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {

                if (hit.collider.CompareTag("Item"))
                {
                    BoughtItem boughtItemScript = hit.collider.GetComponent<BoughtItem>();
                    if (boughtItemScript != null)
                    {
                        if(boughtItemScript.isGood)
                        {
                            Money.instance.Add(boughtItemScript.itemPrice);
                        }
                        else if (!boughtItemScript.isGood)
                        {
                            Money.instance.Add(-boughtItemScript.itemPrice);
                        }
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
