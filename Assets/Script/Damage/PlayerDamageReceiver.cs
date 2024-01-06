using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    protected override void LoadComponents()
    {
        maxHp = GetComponentInParent<PlayerCtrl>().playerData.maxHp;
        healthDisplay = GetComponentInParent<PlayerCtrl>().healthDisplay;

    }

    protected override void OnDead()
    {
        //transform.parent.gameObject.SetActive(false);
        Debug.Log("dead");

    }
}
