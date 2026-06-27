using UnityEngine;

public class Vacuumable : MonoBehaviour
{
    private float stainHealth = 1f;
    private SpriteRenderer spriteRenderer;

    public int money;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Vacuum(int tool)
    {
        if (tool == 1)
        {
            stainHealth -= 1f * Time.deltaTime;
        }
    }

    void Update()
    {
        spriteRenderer.color = new Color(1, 1, 1, stainHealth);

        if (stainHealth <= 0)
        {
            Money.instance.Add(Random.Range(money - 5, money + 10));
            Destroy(gameObject);
        }
    }
}
