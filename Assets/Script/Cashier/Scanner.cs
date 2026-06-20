using UnityEngine;

public class Scanner : MonoBehaviour
{

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
                        Debug.Log("Scanned item: " + boughtItemScript.name + ", Price: " + boughtItemScript.itemPrice + ", Is Good: " + boughtItemScript.isGood);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
    }
}
