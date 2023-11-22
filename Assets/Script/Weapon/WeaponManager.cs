using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class WeaponManager : Singleton<WeaponManager>
{
    //Component
    [SerializeField]
    public WeaponData weaponData;
    private SpriteRenderer wp;

    //Variable
    private bool canShoot = true;
    private Transform spawnPoint;

    private void Start()
    {
        wp = GetComponent<SpriteRenderer>();
        spawnPoint = transform.Find("SpawnPoint");
    }
    private void Update()
    {
        GetWeaponInfo();
    }

    void GetWeaponInfo()
    {
        wp.sprite = weaponData.weaponSprite;
    }

    private void FixedUpdate()
    {
        StartCoroutine(Shooting());

    }

    IEnumerator Shooting()
    {

        if (!IsShooting()) yield break;
        if (!canShoot) yield break;

        Vector3 spawnPos = spawnPoint.position;
        Quaternion rotation = transform.parent.rotation;
        //Transform newBullet = Instantiate(weaponData.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletPool.Instance.Spawn(spawnPos, rotation);
        Debug.Log("Shooting");

        canShoot = false;
        yield return new WaitForSeconds(weaponData.delay);
        canShoot = true;
    }

    bool IsShooting()
    {
        return InputManager.Instance.OnFiring == 1;
    }
}
