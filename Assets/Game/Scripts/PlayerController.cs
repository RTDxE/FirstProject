using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;

    [SerializeField] Rigidbody rigid;
    [SerializeField] Transform cam;
    Vector3 moveDirection = Vector3.zero;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = cam.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward.Normalize();
        Vector3 right = cam.TransformDirection(Vector3.right);
        right.y = 0;
        right.Normalize();
        float curSpeedX = speed * Input.GetAxis("Vertical");
        float curSpeedY = speed * Input.GetAxis("Horizontal");
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        rigid.AddForce(moveDirection);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector3.up * jumpSpeed);
        }
    }
}

