using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    private WalkPoints currentWalkpoint;
    public CashierManager cashierManagerScript;
    private NavMeshAgent agent;

    public void SetWalkpoint(WalkPoints walkpoint)
    {
        currentWalkpoint = walkpoint;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        currentWalkpoint = cashierManagerScript.walkpoints[3];
    }

    private void Update()
    {

        for (int i = 0; i < cashierManagerScript.walkpoints.Length; i++)
        {
            if (cashierManagerScript.walkpoints[i].occupied == false)
            {
                currentWalkpoint.occupied = false;
                agent.SetDestination(cashierManagerScript.walkpoints[i].position);
                cashierManagerScript.walkpoints[i].occupied = true;
                currentWalkpoint = cashierManagerScript.walkpoints[i];
                break;
            }
        }
    }
}
