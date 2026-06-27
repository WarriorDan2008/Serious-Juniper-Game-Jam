using UnityEngine;
using UnityEngine.AI;

public class visitorMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public FoodSO wantedFood;
    public SpriteRenderer wantedfoodpic;
    void Start()
    {
        wantedfoodpic.sprite = wantedFood.sprite;
    }
}
