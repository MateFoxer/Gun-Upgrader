using UnityEngine;

public class Upgrading : MonoBehaviour
{
    public Shooting gunScript;  // Assign the gun's AutomaticShooting script in the Inspector

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding with the wall is the player or the gun
        if (collision.gameObject.CompareTag("Bullet"))  
        {
            // Upgrade the gun when the wall is hit
            gunScript.UpgradeGun();
            Debug.Log("Gun upgraded! Bullets to shoot: " + gunScript.bulletsToShoot);
        }
    }
}
