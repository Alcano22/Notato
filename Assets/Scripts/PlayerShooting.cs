using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] int ammo;
    [SerializeField] Gun gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject bulletIconPrefab;
    [SerializeField] Sound shootSound;
    [SerializeField] UI_AmmoCounter ammoCounter;

    bool reloading;
    float nextShootTime;

    void Start()
    {
        ammo = gun.Capacity;
        for (int i = 0; i < gun.Capacity; i++)
        {
            Instantiate(bulletIconPrefab, Vector2.zero, Quaternion.identity, ammoCounter.transform);
        }
        ammoCounter.UpdateAmmo(ammo);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && nextShootTime <= Time.time)
        {
            if (!reloading)
            {
                if (!HasAmmo)
                {
                    StartCoroutine(ReloadCo());
                    return;
                }

                nextShootTime = Time.time + 60f / gun.Firerate;

                Shoot();
            }
        }
    }

    IEnumerator ReloadCo()
    {
        reloading = true;
        while (ammo < gun.Capacity)
        {
            yield return new WaitForSeconds(gun.ReloadTime / gun.Capacity);

            ammo++;
            ammoCounter.UpdateAmmo(ammo);
        }
        reloading = false;
    }

    void Shoot()
    {
        shootSound.Play();

        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
        bullet.damage = gun.Damage;
        bullet.speed = gun.BulletSpeed;
        bullet.range = gun.Range;

        DrainAmmo();
        ammoCounter.UpdateAmmo(ammo);

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }

    void DrainAmmo()
    {
        ammo -= 1;

        if (ammo < 0)
        {
            ammo = 0;
        }
    }

    public bool HasAmmo => ammo > 0;

    public bool CanShoot => HasAmmo && !reloading;
}
