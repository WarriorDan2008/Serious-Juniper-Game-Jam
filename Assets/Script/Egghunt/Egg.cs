using UnityEngine;

public class Egg : MonoBehaviour
{
    public EggSO egg;
    SpriteRenderer spriteRenderer;
    public int Index;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = egg.eggSprite;
        gameObject.AddComponent<BoxCollider>();
        Index = egg.eggIndex;
    }

    public EggSO TakeEgg()
    {
        DestroyImmediate(gameObject);
        return egg;
    }
}
