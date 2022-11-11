using UnityEngine;

public class FirstScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool destroyer = false;

    private void Update()
    {
        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject == gameObject)
            return;
        if (destroyer) {
            gameObject.SetActive(false);
            Destroy(other.gameObject.GetComponent<FirstScript>(), 2f);
        }
    }
}

