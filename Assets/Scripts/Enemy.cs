using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float attackDamage;

    Transform player;
    Rigidbody2D rb;

    void Awake()
    {
        player = Player.instance.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 movement = Vector2.MoveTowards(rb.position, player.position, movementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(movement);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform other = collision.transform;
        if (!other.CompareTag("Player")) return;

        other.GetComponent<Player>().Damage(attackDamage);

        Destroy(gameObject);
    }
}
