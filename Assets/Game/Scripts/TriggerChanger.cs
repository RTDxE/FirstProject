using UnityEngine;

public class TriggerChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        other.attachedRigidbody.GetComponent<FirstScript>().enabled = true;
    }

    private void OnTriggerExit(Collider other) {
        other.attachedRigidbody.GetComponent<FirstScript>().enabled = false;
    }

}

