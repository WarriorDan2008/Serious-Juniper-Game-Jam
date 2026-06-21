using UnityEngine;

public class Trash : MonoBehaviour
{
    public void Grab(int tool)
    {
        if (tool == 2)
        {
            Destroy(gameObject);
        }
    }
}
