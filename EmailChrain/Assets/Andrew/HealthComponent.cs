using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public UnityEvent OnDeath;
    public UnityEvent OnHealthChanged;
    public float maxHealth;
    public float currentHealth;

    public void Damage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        OnHealthChanged.Invoke();
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }
}