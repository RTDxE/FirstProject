using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float speed = 7.5f;
    public float smooth = 3f;
    public float drag = 0.05f;
    public float airDrag = 0.01f;
    public float jumpSpeed = 8.0f;
    public float attackJumpSpeed = 8.0f;
    public float gravity = 8.0f;

    [SerializeField] Vector3 halfGroundSize = new Vector3(0.5f, 0.5f, 0.5f);

    [SerializeField] Rigidbody rigid;
    [SerializeField] Animator animator;

    private int animSpeedId;
    [SerializeField] private bool isGrounded;
    private bool canJump;

    private void Start()
    {
        animSpeedId = Animator.StringToHash("speed");
    }

    private void OnCollisionStay(Collision other)
    {
        isGrounded = false;
        foreach (var contact in other.contacts)
        {
            if (Vector3.Angle(other.GetContact(0).normal, Vector3.up) < 0.3f)
            {
                isGrounded = true;
                return;
            }
        }
    }

    void FixedUpdate()
    {
        var dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        float curSpeedX = speed * dir.x;
        float curSpeedZ = speed * dir.y;

        var vel = rigid.velocity;

        if (curSpeedX != 0 || curSpeedZ != 0)
        {
            vel.x = Mathf.Lerp(vel.x, curSpeedX, smooth);
            vel.z = Mathf.Lerp(vel.z, curSpeedZ, smooth);
        }
        else if (isGrounded)
        {
            vel.x = Mathf.Lerp(vel.x, 0, drag);
            vel.z = Mathf.Lerp(vel.z, 0, drag);
        }
        else
        {
            vel.x = Mathf.Lerp(vel.x, 0, airDrag);
            vel.z = Mathf.Lerp(vel.z, 0, airDrag);
        }

        if (canJump)
        {
            if (isGrounded)
            {
                vel.y = jumpSpeed;
            }
            canJump = false;
        }

        vel.y -= gravity * Time.fixedDeltaTime;

        rigid.velocity = vel;

        isGrounded = false;
    }

    public void AttackJump()
    {
        var vel = rigid.velocity;
        vel.y = jumpSpeed;
        rigid.velocity = vel;
    }

    public void Damage(int value)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, halfGroundSize * 2f);
    }

    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        animator.SetFloat(animSpeedId, new Vector3(rigid.velocity.x, 0, rigid.velocity.z).sqrMagnitude);
        animator.SetFloat("gravity", rigid.velocity.y);
    }
}