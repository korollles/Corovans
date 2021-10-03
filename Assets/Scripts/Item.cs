using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite icon;
    public string itemName;
    public int ID;
    public int price;
    public int amount;
}
