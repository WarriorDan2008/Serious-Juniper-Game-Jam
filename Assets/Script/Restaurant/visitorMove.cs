using UnityEngine;
using UnityEngine.AI;

public class visitorMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public FoodSO wantedFood;
    public SpriteRenderer wantedfoodpic;
    public int minMoney;
    public int maxMoney;
    void Start()
    {
        wantedfoodpic.sprite = wantedFood.sprite;
    }

    public void AcceptFood(FoodSO GivenFood)
    {
        if (wantedFood.foodName == GivenFood.foodName)
        {
            Money.instance.Add(Random.Range(minMoney, maxMoney));
            Destroy(gameObject);
        }
        else
        {
            Money.instance.Add(Random.Range(-maxMoney, -minMoney));
            Destroy(gameObject);
        }
    }
}
