using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] bool oneShot = false;

    public UnityEvent onEntered;

    private void OnTriggerEnter(Collider other) {
        onEntered.Invoke();

        if (oneShot)
            Destroy(this);
    }
}

