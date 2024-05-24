using UnityEngine;

public enum WeaponType
{
    Gun,
    Sword
}

public class PlayerDI : MonoBehaviour
{
    public IWeapon weapon; 

    public WeaponType selectedWeapon;
    public Transform spawnPoint;
    public PlayerHealth playerHealth;

    private void SelectWeapon(WeaponType weaponType)
    {
        selectedWeapon = weaponType;
        Debug.Log("Selected weapon: " + weaponType);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectWeapon(WeaponType.Gun);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectWeapon(WeaponType.Sword);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackOnEnemy();
        }
    }

    public void WeaponHandle()
    {
        Transform hand = transform.Find("Hand");

        switch (selectedWeapon)
        {
            case WeaponType.Gun:
                if (GameManagerDI.Instance.gunPrefab != null)
                {
                    GameObject tool = Instantiate(GameManagerDI.Instance.gunPrefab, hand.position, hand.rotation, hand);
                    weapon = tool.GetComponent<IWeapon>();
                }
                break;
            case WeaponType.Sword:
                if (GameManagerDI.Instance.swordPrefab != null)
                {
                    GameObject tool = Instantiate(GameManagerDI.Instance.swordPrefab, hand.position, hand.rotation, hand);
                    weapon = tool.GetComponent<IWeapon>();
                }
                break;
            default:
                break;
        }
    }
    private void AttackOnEnemy()
    {
        weapon.Attack();
    }

}
