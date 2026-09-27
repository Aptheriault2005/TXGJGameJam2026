using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;
using System;

public class HealthComponent : MonoBehaviour
{
    public UnityEvent OnDeath = new();
    public UnityEvent OnHealthChanged = new();
    public float maxHealth;
    public float currentHealth;

    public void Damage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        OnHealthChanged?.Invoke();   
        if (currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void Kill()
    {
        currentHealth = 0;
        OnHealthChanged?.Invoke();
        OnDeath?.Invoke();
    }
}