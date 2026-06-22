using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject visitorPrefab;
    private Vector3 spawnPos1 = new Vector3(0, 1, 9);
    private Vector3 spawnPos2 = new Vector3(0, 1, -9);
    private Vector3 spawnPos3 = new Vector3(-9, 1, 0);
    private Vector3 spawnPos4 = new Vector3(9, 1, 0);

    private float startDelay = 3;
    private float repeatRate = 3;

    public Vector3[] spawnPoints;

   

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

        Instantiate(visitorPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)], visitorPrefab.transform.rotation);
    }
    

     
    
}
