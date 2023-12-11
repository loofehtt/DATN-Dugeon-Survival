using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    private DamageSender damageSender;
    private void Awake()
    {
        damageSender = GetComponent<DamageSender>();
    }

    protected override void DespawnObj()
    {
        BulletPool.Instance.Despawn(transform);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Collison: " + collision.gameObject.tag);

            BulletPool.Instance.Despawn(transform);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            damageSender.Send(collision.transform);

        }
    }



}

