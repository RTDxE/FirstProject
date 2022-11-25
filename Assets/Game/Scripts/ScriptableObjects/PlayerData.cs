using UnityEngine;
using MergeRace;

[CreateAssetMenu(menuName = "Objects/PlayerData")]
public class PlayerData : StorableObject
{
    public Vector3 position;

    public int hp;
    public int moveSpeed;
    public bool isEnemy;
}
