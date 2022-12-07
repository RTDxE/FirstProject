using UnityEngine;

public class PointShadow : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] float minDistance = 1f;
    [SerializeField] float maxDistance = 2f;

    private Vector3 defaultScale;

    private void Start()
    {
        defaultScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.parent.position, Vector3.down, out var hit, 1000f, 1, QueryTriggerInteraction.Ignore))
        {
            transform.position = hit.point + Vector3.up * 0.05f;
            Color c = meshRenderer.material.color;
            c.a = (Mathf.Clamp(hit.distance, minDistance, maxDistance) - minDistance) / (maxDistance - minDistance);
            meshRenderer.material.color = c;

            transform.localScale = defaultScale * Mathf.Clamp(hit.distance, 0, 5) / 2;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }
}