using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemySO : ScriptableObject
{
    [Header("Move State")]
    public float moveSpeed = 2f;
    public float chaseRange = 10f;
    public float attackRange = 4f;
    [Header("Stats")]
    public int hp = 10;
    public int damage = 1;
}
