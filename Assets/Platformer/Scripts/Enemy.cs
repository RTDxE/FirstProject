using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] float speed;

    private Transform target;
    private DinoController dc;

    [SerializeField] Rigidbody rigid;

    public void Damage(int value)
    {
        Instantiate(particles, transform.position, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            var vel = rigid.velocity;
            var dir = (target.position - transform.position);
            dir.y = 0;
            dir.Normalize();
            vel = new Vector3(dir.x * speed, vel.y, dir.z * speed);
            rigid.velocity = vel;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (target == null && other.attachedRigidbody != null)
        {
            if (other.attachedRigidbody.TryGetComponent<DinoController>(out dc))
            {
                target = dc.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (target != null && other.attachedRigidbody != null && target == other.attachedRigidbody.transform)
            target = null;
    }
}