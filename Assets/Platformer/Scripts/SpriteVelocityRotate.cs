using UnityEngine;

public class SpriteVelocityRotate : MonoBehaviour
{
    [SerializeField] float smooth = 3f;
    [SerializeField] float angle = 15f;

    [SerializeField] Rigidbody rigid;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (Mathf.Abs(rigid.velocity.x) > 0.1f) 
        {
            spriteRenderer.flipX = rigid.velocity.x < 0;
        }

        transform.rotation = Quaternion.Lerp(
            transform.rotation, 
            Quaternion.Euler(0, angle * rigid.velocity.z / 3f * (spriteRenderer.flipX ? 1 : -1), 0), 
            smooth * Time.deltaTime
        );
    }
}
