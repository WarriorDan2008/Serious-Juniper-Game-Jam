using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Customer : MonoBehaviour
{
    public CashierManager cashierManagerScript;

    public NavMeshAgent agent;

    public BoughtItemSO[] ItemTemplates;
    public GameObject boughtItem;

    public float cooldownTime = 2f;
    float cooldownTimer = 0f;
    public bool ReachedDestinationOrGaveUp()
    {

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public IEnumerator DIE(Vector3 destination)
    {
        agent.SetDestination(destination);
        yield return new WaitUntil(() => ReachedDestinationOrGaveUp());
        Destroy(gameObject);
        yield return null;
    }

    void Update()
    {
        ReachedDestinationOrGaveUp();
        if(ReachedDestinationOrGaveUp())
        {
            cooldownTimer -= 1f * Time.deltaTime;
            if(cooldownTimer <= 0f)
            {
                SpawnItem();
                cooldownTimer = cooldownTime;
            }
        }
    }

    void SpawnItem()
    {
        GameObject item = Instantiate(boughtItem, new Vector3(2f, -1f, Random.Range(-6.25f, -5.75f)), Quaternion.identity);
        item.GetComponent<BoughtItem>().boughtItem = ItemTemplates[Random.Range(0, ItemTemplates.Length)];

    }
}
