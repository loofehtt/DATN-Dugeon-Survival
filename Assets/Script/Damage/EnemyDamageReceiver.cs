using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    protected override void LoadComponents()
    {
        maxHp = GetComponentInParent<EnemyCtrl>().enemyData.maxHp;
        healthDisplay = GetComponentInParent<EnemyCtrl>().healthDisplay;
    }
    protected override void OnDead()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
