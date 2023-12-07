using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]
public class EnemySO : ScriptableObject
{
    [Header("Move State")]
    public float moveSpeed = 2f;
}
