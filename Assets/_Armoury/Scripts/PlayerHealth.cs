using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int amount);
}

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        // Check if player health drops below zero
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("Player took " + amount + " damage. Current health: " + currentHealth);
        }
    }

    private void Die()
    {
        // Implement player death logic (e.g., show game over screen, reset level, etc.)
        Debug.Log("Player died!");
    }
}
