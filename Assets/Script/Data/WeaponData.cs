using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Base Data")]
public class WeaponData : ScriptableObject
{
    [Header("Sprite")]
    public Sprite weaponSprite;
    public Transform bulletPrefab;
    public Transform explodeFx;
    [Header("Property")]
    public int damage = 1;
    public float delay = 1f;
}
