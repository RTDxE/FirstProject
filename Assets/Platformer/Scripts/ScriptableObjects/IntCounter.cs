using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "IntCounter", menuName = "Objects/IntCounter", order = 1)]
public class IntCounter : ScriptableObject
{
    public UnityEvent onValueChanged;

    [SerializeField] private int count = 0;
    public int Count
    {
        get => count; 
        set
        {
            count = value;
            onValueChanged.Invoke();
        }
    }

    public void Collect(Pickup data)
    {
        Count += data.count;
    }

    public void Reset()
    {
        Count = 0;
    }
}
