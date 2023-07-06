using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] float despawnDelay;
    [SerializeField] float despawnIndicateTime;
    [SerializeField] SpriteRenderer spriteRenderer;

    float despawnTime;

    void Start()
    {
        despawnTime = Time.time + despawnDelay;

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), enemy.GetComponent<Collider2D>());
        }
        foreach (GameObject bullet in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
        }
    }

    void Update()
    {
        if (Time.time >= despawnTime - despawnIndicateTime)
        {
            Color color = spriteRenderer.color;
            color.a = Mathf.Abs(Mathf.Sin(Time.time * 20f));
            spriteRenderer.color = color;
        }

        if (Time.time >= despawnTime)
        {
            Destroy(gameObject);
        }
    }
}
