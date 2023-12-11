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
    private int currentWp = 1;

    private void Start()
    {
        wp = GetComponent<SpriteRenderer>();
        spawnPoint = transform.Find("SpawnPoint");
    }
    private void Update()
    {
        LoadWeapon();
        ChangeWeapon();
    }

    void LoadWeapon()
    {
        string resPath = "Weapon/Weapon_" + currentWp;
        WeaponData = Resources.Load<WeaponSO>(resPath);

        wp.sprite = WeaponData.weaponSprite;
    }

    void ChangeWeapon()
    {
        string[] wpQuantity = Directory.GetFiles("Assets/Resources/Weapon", "*.asset", SearchOption.AllDirectories);

        if (InputManager.Instance.OnSwitch)
        {
            currentWp++;

            if (currentWp > wpQuantity.Length)
            {
                currentWp = 1;
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
        //Transform newBullet = Instantiate(weaponData.bulletPrefab, spawnPos, rotation);
        Transform newBullet = BulletPool.Instance.Spawn(spawnPos, rotation);
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
