using TMPro;
using UnityEngine;

public class ItemPrefabData : MonoBehaviour
{
    private int _count = 0;
    public int Count
    {
        get => _count;
        set
        {
            countText.text = value.ToString();
            _count = value;
        }
    }

    [SerializeField] private TMP_Text countText;
}
