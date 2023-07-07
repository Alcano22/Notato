using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public float range;

    [SerializeField] GameObject bulletBurstPrefab;

    Vector2 spawnPos;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        foreach (GameObject heart in GameObject.FindGameObjectsWithTag("Heart"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), heart.GetComponent<Collider2D>());
        }
    }

    void Start()
    {
        spawnPos = transform.position;

        IgnoreAllBulletCollisions();
    }

    void IgnoreAllBulletCollisions()
    {
        foreach (Bullet bullet in FindObjectsOfType<Bullet>())
        {
            if (bullet == this) continue;

            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = transform.right * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);

        if (Vector2.Distance(spawnPos, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform other = collision.transform;
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Damage(damage);
        }

        BurstParticles particles = Instantiate(bulletBurstPrefab, transform.position, Quaternion.identity).GetComponent<BurstParticles>();
        particles.Emit();

        Destroy(gameObject);
    }
}
