using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int MaxHealth;

    //protected int CurrentHealth;
    public int CurrentHealth;

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
        int minHealth = 0;
        CurrentHealth += treatmentEffect;
        CurrentHealth = Mathf.Clamp(CurrentHealth, minHealth, MaxHealth);
        Debug.Log(CurrentHealth);
    }
}
