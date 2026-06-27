using UnityEngine;

public class Stain : MonoBehaviour
{
    private float stainHealth = 1f;
    public int money;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Clean(int tool)
    {
        if (tool == 0)
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
