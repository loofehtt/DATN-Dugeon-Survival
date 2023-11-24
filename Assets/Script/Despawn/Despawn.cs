using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Despawn : MonoBehaviour
{
    [SerializeField] protected float despawnDelay = 2f;
    protected float despawnTimer = 0f;

    private void OnEnable()
    {
        despawnTimer = 0f;
    }
    private void FixedUpdate()
    {
        CanDespawnObj();
    }

    protected virtual void CanDespawnObj()
    {
        despawnTimer += Time.fixedDeltaTime;
        if (despawnTimer < despawnDelay) return;
        DespawnObj();
    }

    protected abstract void DespawnObj();

}