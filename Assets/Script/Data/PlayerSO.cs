using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerSO : ScriptableObject
{
    [Header("Move State")]
    public float moveSpeed = 10f;
    [Header("Stats")]
    public int maxHp = 5;
}
