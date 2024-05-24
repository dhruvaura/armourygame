using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    public float swordRange;
    public int willDamage;

    public void Attack()
    {
        // Perform a slashing action
        Debug.Log("Sword slashes!");

        foreach (EnemyDI enemy in GameManagerDI.Instance.enemies)
        {
            // Calculate the distance between the player and the enemy
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // Check if the enemy is within sword range
            if (distance < swordRange)
            {
                // Attack the enemy
                enemy.TakeDamage(willDamage);
            }
        }
    }


}
