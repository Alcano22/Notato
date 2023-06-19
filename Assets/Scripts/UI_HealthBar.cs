using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        slider.value = health / maxHealth;
    }
}
