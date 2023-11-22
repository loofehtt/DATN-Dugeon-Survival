using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField] private float despawnDelay = 2f;
    [SerializeField] private float despawnTimer = 0f;

    private void Update()
    {
        DespawnObj();
    }

    void DespawnObj()
    {
        despawnTimer += Time.fixedDeltaTime;
        if (despawnTimer < despawnDelay) return;
        despawnTimer = 0f;

        BulletPool.Instance.Despawn(this.transform);

    }
}

