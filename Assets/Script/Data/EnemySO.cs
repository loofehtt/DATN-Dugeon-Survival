using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemySO : ScriptableObject
{
    [Header("Move Stats")]
    public float moveSpeed = 2f;
    public float chaseRange = 10f;
    public float attackRange = 4f;
    [Header("Stats")]
    public int maxHp = 10;
    [Header("Attack Stats")]
    public bool isMelee;
    public int damage = 1;
    public float attackDelay = 2f;
}
