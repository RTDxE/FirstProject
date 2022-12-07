using UnityEngine;
using UnityEngine.Events;

public class EnemyDamager : MonoBehaviour
{

    public UnityEvent onDamaged;
    
    private void OnTriggerEnter(Collider other)
    {

        if (!other.isTrigger && other.attachedRigidbody != null && other.attachedRigidbody.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.Damage(0);
            onDamaged.Invoke();
        }
    }
}
