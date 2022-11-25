using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    [SerializeField] private PlayerData data;

    private Vector3 lastDataPos;

    private void Start()
    {
        data.LoadFromFile();
        data.onLoaded += UpdatePosFromData;
    }

    private void UpdatePosFromData()
    {
        Debug.Log("pos updated");
        transform.position = data.position;
    }

    private void Update()
    {
        if (data.position != lastDataPos)
            transform.position = data.position;

        data.position = transform.position;
        lastDataPos = data.position;
    }

    private void OnApplicationQuit()
    {
        data.onLoaded -= UpdatePosFromData;
        data.SaveToFile();
    }
}
