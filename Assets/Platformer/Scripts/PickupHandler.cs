using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    [SerializeField] IntCounter moneyCounter;
    [SerializeField] Pickup data;

    public void Collect()
    {
        moneyCounter.Collect(data);

        Destroy(gameObject);
    }
}
