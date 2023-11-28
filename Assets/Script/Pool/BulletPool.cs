using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<BulletPool>
{
    public override Transform Spawn(Vector3 spawnPos, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool(WeaponManager.Instance.WeaponData.bulletPrefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.transform;
        newPrefab.gameObject.SetActive(true);
        return newPrefab;
    }

    public override void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        FxPool.Instance.Spawn(obj.transform.position, obj.transform.rotation);
    }

}
