using UnityEngine;

public interface IEnemyBehavior
{
    void TakeDamage(int amount);
}

public class EnemyDI : MonoBehaviour, IEnemyBehavior, IEnemyAttack
{
    private int health = 100; // Initial health of the enemy
    private float attackRange = 1f; // Adjust this value according to your game's requirements

    private IEnemyAttack enemyAttack;

    private PlayerDI player;

    private void Start()
    {
        player = FindObjectOfType<PlayerDI>();
    }

    public EnemyDI(IEnemyAttack enemyAttack)
    {
        this.enemyAttack = enemyAttack;
    }

    public void Attack()
    {
        enemyAttack.Attack();
    }


    // Method to receive damage
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle enemy death
    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); 
    }

    private void Update()
    {
        if (IsPlayerInRange())
        {
            // If player is in range, initiate attack
            AttackPlayer();
        }
    }

    private bool IsPlayerInRange()
    {
        // Check if player is within attack range
        return Vector3.Distance(transform.position, player.transform.position) <= attackRange;
    }

    private void AttackPlayer()
    {
        // Perform attack on the player using the behavior
        enemyAttack.Attack();
    }
}

public interface IEnemyAttack
{
    void Attack();
}

public class BasicEnemyBehavior : IEnemyAttack
{
    private int punchDamage = 10; // Adjust this value according to your requirements
    private PlayerDI player;

    public BasicEnemyBehavior(PlayerDI player)
    {
        this.player = player;
    }

    public void Attack()
    {
        // do sword animation of ai
        player.playerHealth.TakeDamage(punchDamage);
    }

}

public class AdvancedEnemyBehavior : IEnemyAttack
{
    private int swordDamage = 25; // Adjust this value according to your requirements
    private PlayerDI player;

    public AdvancedEnemyBehavior(PlayerDI player)
    {
        this.player = player;
    }

    public void Attack()
    {
        // do sword animation of ai
        player.playerHealth.TakeDamage(swordDamage);
    }

}
