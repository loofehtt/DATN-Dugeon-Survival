using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxDespawn : Despawn
{
    protected override void DespawnObj()
    {
        FxPool.Instance.Despawn(transform);
    }
}

