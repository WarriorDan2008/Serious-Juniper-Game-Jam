using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "BoughtItem", menuName = "Cashier/BoughtItem")]
public class BoughtItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemPrice;
    public bool isGood;
}
