using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class FirstScript : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private bool destroyer = false;
    [SerializeField] private float _size = 2.0f;
    [SerializeField] private float time = 0;

    Coroutine coroutine;

    public UnityEvent onCoroutineEnded;


    private void Start()
    {
        coroutine = StartCoroutine(SimpleCoroutine());
        onCoroutineEnded.AddListener(IncokeCall);
        onCoroutineEnded.AddListener(() =>
        {
            Debug.Log("NOT  IncokeCall");
        });
    }

    IEnumerator SimpleCoroutine()
    {
        yield return new WaitUntil(() => time > 1f);

        // while (time <= 5f)
        //     yield return null;

        Debug.Log("asaas");
        onCoroutineEnded.Invoke();
    }

    private void IncokeCall()
    {
        Debug.Log("IncokeCall");
    }

    private void Update()
    {
        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);

        time += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == gameObject)
            return;
        if (destroyer)
        {
            gameObject.SetActive(false);
            Destroy(other.gameObject.GetComponent<FirstScript>(), 2f);
        }

        if (coroutine != null)
            StopCoroutine(coroutine);

        StopAllCoroutines();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one * _size);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _size);
    }
}

