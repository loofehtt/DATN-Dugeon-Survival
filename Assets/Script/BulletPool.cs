using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    [SerializeField] private List<Transform> poolObjs;

    private void Reset()
    {
        LoadComponents();
    }
    void LoadComponents()
    {

    }


    public Transform Spawn(Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool();
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.transform;
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

    Transform GetObjectFromPool()
    {
        Transform prefab = WeaponManager.Instance.weaponData.bulletPrefab;
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

    public void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

}
