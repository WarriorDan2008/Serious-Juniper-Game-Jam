using UnityEngine;
using UnityEngine.AI;

public class CashierManager : MonoBehaviour
{
    public Vector3 spawnPoint = new Vector3(-7f, -3f, -15f);
    public Vector3 cashierPoint = new Vector3(0f, -3f, -15f);
    public Vector3 exitPoint = new Vector3(12f, -3f, -15f);
    public GameObject customerPrefab;
    private Customer currentCustomer;
    float spawnTimer;

    void Start()
    {
        CreateCustomer();
    }

    void CreateCustomer()
    {
        if (currentCustomer != null)
        {
            currentCustomer.StartCoroutine(currentCustomer.DIE(exitPoint));
        }
        GameObject createdCustomer = Instantiate(customerPrefab, spawnPoint, Quaternion.identity);
        currentCustomer = createdCustomer.GetComponent<Customer>();
        currentCustomer.cashierManagerScript = this;
        currentCustomer.SetDestination(cashierPoint);
        spawnTimer = Random.Range(10f, 30f);
    }

    void Update()
    {
        spawnTimer -= 1f * Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            CreateCustomer();
        }
    }
}