using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Gun gun;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Sound shootSound;

    float nextShootTime;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && nextShootTime <= Time.time)
        {
            nextShootTime = Time.time + 60f / (float)gun.Firerate;

            Shoot();
        }
    }

    void Shoot()
    {
        shootSound.Play();

        Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
        bullet.damage = gun.Damage;
        bullet.speed = gun.BulletSpeed;
        bullet.range = gun.Range;

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
}
