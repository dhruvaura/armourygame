using UnityEngine;

public interface IWeapon
{
    void Attack();
}

public class Gun : MonoBehaviour, IWeapon
{
    private GameObject bulletPrefab; 
    private Transform firePoint;
    public int willDamage;

    // Method for injecting dependencies
    public void Initialize(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }

    public void Attack()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Optionally, you can add force to the bullet if it has a Rigidbody component
            bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * 5, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Bullet prefab or fire point is not assigned in the Gun script!");
        }
    }
}
