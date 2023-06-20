using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] float health;
    [SerializeField] float maxHealth;
    [SerializeField] Sound hurtSound;
    [SerializeField] UI_HealthBar healthBar;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        healthBar.UpdateHealth(health, maxHealth);
    }

    void OnValidate()
    {
        healthBar.UpdateHealth(health, maxHealth);
    }

    public void Damage(float damage)
    {
        if (damage <= 0) return;

        hurtSound.Play();

        health -= damage;
        if (health <= 0)
        {
            health = 0;

            Game.Instance.OnPlayerDie();
        }

        healthBar.UpdateHealth(health, maxHealth, true);
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
