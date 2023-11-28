using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    protected override void DespawnObj()
    {
        BulletPool.Instance.Despawn(transform);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Collison");
            BulletPool.Instance.Despawn(transform);
        }
    }

}

