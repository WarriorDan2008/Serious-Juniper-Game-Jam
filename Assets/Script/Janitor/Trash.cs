using UnityEngine;

public class Trash : MonoBehaviour
{
    public int money = 30;
    public void Grab(int tool)
    {
        if (tool == 2)
        {
            Money.instance.Add(Random.Range(money - 5, money + 10));
            Destroy(gameObject);
        }
    }
}
