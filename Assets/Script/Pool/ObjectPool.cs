using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : Singleton<T> where T : MonoBehaviour
{
    [SerializeField] protected List<Transform> poolObjs;

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public abstract Transform Spawn(Vector3 spawnPos, Quaternion rotation);
    public abstract void Despawn(Transform obj);
}