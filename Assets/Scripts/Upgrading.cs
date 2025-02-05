using UnityEngine;

public class GunStats : MonoBehaviour
{
    public int damage = 1;
    public float fireRate = 1f;

    public void Upgrade()
    {
        damage += 1;
        fireRate += 0.1f;
        Debug.Log("Gun Upgraded! Damage: " + damage + ", Fire Rate: " + fireRate);
    }

    public void Downgrade()
    {
        damage -= 1;
        fireRate -= 0.1f;
        Debug.Log("Gun Downgraded! Damage: " + damage + ", Fire Rate: " + fireRate);
    }
}