using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int MaxHealth = 100;

    protected int CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int treatmentEffect)
    {
        if (CurrentHealth != MaxHealth)
        {
            CurrentHealth += treatmentEffect;
        }
    }
}
