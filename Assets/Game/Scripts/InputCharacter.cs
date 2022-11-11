using UnityEngine;

public class InputCharacter : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            var pos = transform.position;
            pos.y += speed * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            var pos = transform.position;
            pos.y -= speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}

