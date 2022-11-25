using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform playerCameraParent;
    public Transform player;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    private void Start()
    {
        rotation.y = transform.eulerAngles.y;
    }

    private void Update()
    {
        rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
        // playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        transform.eulerAngles = rotation;
    }

    private void LateUpdate()
    {
        transform.position = player.position;
    }
}