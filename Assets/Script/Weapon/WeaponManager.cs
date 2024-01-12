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
    private bool canShoot = true;
    private Transform spawnPoint;
    public int currentWp = 1;
    public string[] wpQuantity { get; private set; }

    private void Start()
    {
        wpQuantity = Directory.GetFiles("Assets/Resources/Weapon", "*.asset", SearchOption.AllDirectories);
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
        string resPath = "Weapon/Weapon_" + currentWp;
        WeaponData = Resources.Load<WeaponSO>(resPath);

        wp.sprite = WeaponData.weaponSprite;
    }

    void UpgradeWeapon()
    {
        if (InputManager.Instance.OnSwitch)
        {
            currentWp++;

            if (currentWp > wpQuantity.Length)
            {
                currentWp = wpQuantity.Length;
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

        if (currentWp == 1)
        {
            Transform newBullet = BulletPool.Instance.Spawn(BulletPool.bulletOne, spawnPos, rotation);
        }
        else
        {
            Transform newBullet = BulletPool.Instance.Spawn(BulletPool.bulletTwo, spawnPos, rotation);
        }

        Debug.Log("Shooting");

        canShoot = false;
        yield return new WaitForSeconds(WeaponData.delay);
        canShoot = true;
    }

    bool IsShooting()
    {
        return InputManager.Instance.OnFire == 1;
    }
}
