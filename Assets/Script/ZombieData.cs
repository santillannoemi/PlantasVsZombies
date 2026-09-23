using UnityEngine;

[CreateAssetMenu(fileName = "ZombieData", menuName = "Scriptable Objects/ZombiData")]
public class ZombieData : ScriptableObject
{
    public float maxHealth;
    public float moveSpeed;
    public float damage;
    public float attackRange;
}
