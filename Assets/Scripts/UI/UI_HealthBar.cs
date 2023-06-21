using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthBar : MonoBehaviour
{
    [SerializeField] float smoothTime;

    float targetValue;
    float valueRef;
    Slider slider;
    Animator animator;

    void Awake()
    {
        slider = GetComponent<Slider>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        slider.value = Mathf.SmoothDamp(slider.value, targetValue, ref valueRef, smoothTime);
    }

    public void UpdateHealth(float health, float maxHealth, bool damage = false)
    {
        targetValue = health / maxHealth;

        if (damage)
        {
            animator.SetTrigger("Shake");
        }
    }
}
