using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLoader : MonoBehaviour
{
    [SerializeField] private List<InvItem> items;
    [SerializeField] private GameObject itemPrefab;

    private void Start()
    {
        foreach (InvItem item in items)
        {
            GameObject prefab = Instantiate(itemPrefab, transform);

            prefab.GetComponent<ItemPrefabData>().Count = item.count;
            prefab.GetComponent<Image>().sprite = item.item.icon;
        }
    }
}

[System.Serializable]
public class InvItem
{
    public ItemObject item;
    public int count;
}
