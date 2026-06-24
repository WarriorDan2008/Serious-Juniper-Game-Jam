using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "BoughtItem")]
public class BoughtItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemPrice;
    public bool isGood;
}
