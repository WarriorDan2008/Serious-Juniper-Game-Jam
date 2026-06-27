using UnityEngine.UI;
using UnityEngine;

public class GiveFood : MonoBehaviour
{

    public Camera foodCam;
    private RaycastHit hit;

    public FoodSO heldFood;
    public Image heldFoodImage;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                // Do something when the ray hits an object
                if (hit.transform.CompareTag("Food"))
                {
                    Foods f = hit.transform.GetComponent<Foods>();
                    heldFood = f.food;

                    heldFoodImage.sprite = heldFood.sprite;
                }
                else if (hit.transform.CompareTag("Visitor"))
                {
                    visitorMove v = hit.transform.GetComponent<visitorMove>();
                    v.AcceptFood(heldFood);
                }
            }
        }
    }


}



