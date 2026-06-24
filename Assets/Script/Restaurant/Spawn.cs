using UnityEngine;
using UnityEngine.AI;


public class Spawn : MonoBehaviour
{
    public GameObject visitorPrefab;
    
    public FoodSO[] foodItems;
    private float startDelay = 3;
    private float repeatRate = 3;

    public Vector3[] spawnPoints;

    public Vector3[] eatPoints;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnVisitor", startDelay, repeatRate);
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnVisitor()
    {
        
        int doorNum;

        doorNum = Random.Range(0, spawnPoints.Length);
        
        GameObject v = Instantiate(visitorPrefab, spawnPoints[doorNum], visitorPrefab.transform.rotation);

        visitorMove vscript = v.GetComponent<visitorMove>(); 
        vscript.wantedFood = foodItems[Random.Range(0, foodItems.Length)];
        vscript.agent.SetDestination(eatPoints[doorNum]);
        

        
            
        
    }
    

     
    
}
