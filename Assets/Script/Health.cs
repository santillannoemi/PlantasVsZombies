using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    [SerializeField]
    private UnityEvent onDeath;
    [SerializeField]
    private UnityEvent onTakeDamage;
    private float CurrentHealth;
    private float maxHealth;
    public bool IsDead => CurrentHealth <= 0;
    public void SetMaxHealth(float health)
    {
        maxHealth = health;
    }
    public void Initialize()
    {
        CurrentHealth = maxHealth;
        UpdateHealthSlider();
    }
    private void UpdateHealthSlider()
    {
        healthSlider.value = CurrentHealth / maxHealth;
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        onTakeDamage?.Invoke();
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            onDeath?.Invoke();
        }
        UpdateHealthSlider();
    }
}
