using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float HEART_DROP_CHANCE = 5f / 100f;

    [SerializeField] float health;
    [SerializeField] float movementSpeed;
    [SerializeField] float attackDamage;
    [SerializeField] Sound hitSound;
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject burstParticlesPrefab;
    [SerializeField] SpriteRenderer spriteRenderer;

    Transform player;
    Rigidbody2D rb;

    void Awake()
    {
        player = Player.Instance.transform;
        rb = GetComponent<Rigidbody2D>();

        foreach (GameObject heart in GameObject.FindGameObjectsWithTag("Heart")) {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), heart.GetComponent<Collider2D>());
        }
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

        DropHeart();

        EmitParticles();

        Destroy(gameObject);
    }

    void EmitParticles()
    {
        BurstParticles particles = Instantiate(burstParticlesPrefab, transform.position, Quaternion.identity).GetComponent<BurstParticles>();
        particles.Emit(spriteRenderer.color);
    }

    void DropHeart()
    {
        if (Random.value > HEART_DROP_CHANCE) return;

        Instantiate(heartPrefab, transform.position, Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform other = collision.transform;
        if (!other.CompareTag("Player")) return;

        Game.Instance.CurrentWave.OnEnemyHitPlayer();
        EmitParticles();

        other.GetComponent<Player>().Damage(attackDamage);
        Destroy(gameObject);
    }
}
