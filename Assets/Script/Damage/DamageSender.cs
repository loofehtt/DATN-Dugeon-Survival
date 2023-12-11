using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MonoBehaviour
{
    [SerializeField] protected int damage = 1;
    public void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.gameObject.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver != null)
        {
            SendDmg(damageReceiver);
        }
    }

    public void SendDmg(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(damage);
    }
}
