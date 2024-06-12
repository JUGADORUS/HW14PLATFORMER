using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;

    protected int currentHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
