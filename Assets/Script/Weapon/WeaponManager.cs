using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WeaponManager : Singleton<WeaponManager>
{
    //Component
    public WeaponSO WeaponData { get; private set; }
    private SpriteRenderer wp;

    //Variable
    public WeaponSO[] Weapons;
    private Transform spawnPoint;
    public bool canShoot = true;
    public int currentWp;

    private void Start()
    {
        currentWp = 0;
        wp = GetComponent<SpriteRenderer>();
        spawnPoint = transform.Find("SpawnPoint");
    }
    private void Update()
    {
        LoadWeapon();
        UpgradeWeapon();
    }

    void LoadWeapon()
    {
        WeaponData = Weapons[currentWp];

        wp.sprite = WeaponData.weaponSprite;
    }

    void UpgradeWeapon()
    {
        if (InputManager.Instance.OnSwitch)
        {
            currentWp++;

            if (currentWp > Weapons.Length - 1)
            {
                currentWp = Weapons.Length - 1;
                Debug.Log("This is the strongest weapon");
            }

            Debug.Log("Weapon: " + currentWp);
        }

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

        Transform newBullet = BulletPool.Instance.Spawn(BulletPool.playerBullet + (currentWp + 1).ToString(), spawnPos, rotation);

        //Debug.Log("Shooting");

        canShoot = false;
        yield return new WaitForSeconds(WeaponData.delay);
        canShoot = true;
    }

    bool IsShooting()
    {
        return InputManager.Instance.OnFire == 1;
    }
}
