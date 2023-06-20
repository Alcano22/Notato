using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public float range;

    Vector2 spawnPos;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        spawnPos = transform.position;
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

        Destroy(gameObject);
    }
}
