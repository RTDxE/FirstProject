using UnityEngine;


[CreateAssetMenu(menuName = "Objects/Item")]
public class ItemObject: ScriptableObject
{
    public string name;
    public int price;
    public Sprite icon;
}
