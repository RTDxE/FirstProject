using UnityEngine;

public class CounterReset : MonoBehaviour
{
    [SerializeField] IntCounter counter;

    private void Start()
    {
        counter.Reset();
    }
}