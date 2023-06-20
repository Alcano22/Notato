using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float movementSpeed;
    [SerializeField] float attackDamage;
    [SerializeField] Sound hitSound;

    Transform player;
    Rigidbody2D rb;

    void Awake()
    {
        player = Player.Instance.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 movement = Vector2.MoveTowards(rb.position, player.position, movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(movement);
    }

    public void Damage(float damage)
    {
        if (damage < 0) return;

        health -= damage;

        hitSound.Play();

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Game.Instance.CurrentWave.OnEnemyKill();

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform other = collision.transform;
        if (!other.CompareTag("Player")) return;

        other.GetComponent<Player>().Damage(attackDamage);
        Destroy(gameObject);
    }
}
