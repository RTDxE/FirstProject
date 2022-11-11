using UnityEngine;

public class Remover : MonoBehaviour
{
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
        {
            hit.transform.localScale *= Random.Range(0.96f, 1.04f);
            Debug.DrawLine(ray.origin, ray.direction * hit.distance, Color.red);

            if (Input.GetMouseButton(0))
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.direction * 1000f, Color.green);
        }

    }
}

