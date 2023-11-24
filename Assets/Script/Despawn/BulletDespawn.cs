using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : Despawn
{
    protected override void DespawnObj()
    {
        BulletPool.Instance.Despawn(transform);

    }
}

