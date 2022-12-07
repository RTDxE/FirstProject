using UnityEngine;

public class Enemy : MonoBehaviour
{

    public void Damage(int value)
    {
        Destroy(gameObject);
    }
}