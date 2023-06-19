using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] UI_HealthBar healthBar;

    void Awake()
    {
        instance = this;
    }

    public void Damage(float damage)
    {
        if (damage <= 0) return;

        health -= damage;
        if (health < 0)
        {
            health = 0;
        }

        healthBar.UpdateHealth(health, maxHealth);
    }

    public void Heal(float heal)
    {
        if (heal <= 0) return;

        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        healthBar.UpdateHealth(health, maxHealth);
    }
}
