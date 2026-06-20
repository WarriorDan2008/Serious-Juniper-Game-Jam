using UnityEngine;
using UnityEngine.AI;

public class CashierManager : MonoBehaviour
{
    private Vector3 spawnpoint = new Vector3(12.1619997f,-0.0485799983f,5.33099985f);
    public WalkPoints[] walkpoints;
    public WalkPoints exitPoint;
    public GameObject customerPrefab;

    private Customer currentCustomer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject createdCustomer = Instantiate(customerPrefab, spawnpoint, Quaternion.identity);
            currentCustomer = createdCustomer.GetComponent<Customer>();
            currentCustomer.cashierManagerScript = this;
        }
    }
}
