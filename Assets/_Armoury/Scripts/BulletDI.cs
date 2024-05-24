using UnityEngine;

public class BulletDI : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyDI enemy = other.GetComponent<EnemyDI>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
        Destroy(gameObject);
    }
}
