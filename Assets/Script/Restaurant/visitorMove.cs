using UnityEngine;
using UnityEngine.AI;

public class visitorMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public FoodSO wantedFood;
    public SpriteRenderer wantedfoodpic;

    

    


    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        wantedfoodpic.sprite = wantedFood.sprite;
    }

    // Update is called once per frame

    

   
    
}
