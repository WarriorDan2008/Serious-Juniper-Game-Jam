using UnityEngine;
using UnityEngine.       UI;

public class BoughtItem : MonoBehaviour
{
    public int itemPrice;
    public bool isGood;
    public BoughtItemSO boughtItem;
    SpriteRenderer image;
    Rigidbody rb;

    float destroyTimer = 4f;

    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        image = GetComponent<SpriteRenderer>();
        if (boughtItem != null)
        {
            itemPrice = boughtItem.itemPrice;
            isGood = boughtItem.isGood;
            image.sprite = boughtItem.itemSprite;
        }
    }

    void Update()
    {
        rb.AddForce(new Vector3(-25f, 0f, 0f) * Time.deltaTime, ForceMode.VelocityChange);
        destroyTimer -= 1f * Time.deltaTime;
        if (destroyTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
