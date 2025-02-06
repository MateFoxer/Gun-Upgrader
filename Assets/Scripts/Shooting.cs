using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Assign your bullet prefab in the Inspector
    public Transform firePoint;      // Assign the FirePoint GameObject here
    public float fireRate = 0.2f;    // Time between shots (in seconds)
    public float bulletForce = 20f;  // Speed of the bullet
    public int bulletsToShoot = 1;   // Start with 1 bullet shot
    public float bulletDelay = 0.1f; // Delay between each bullet (in seconds)

    private float nextFireTime = 0f; // Time when the next shot can be fired

    void Update()
    {
        // Check if it's time to fire again
        if (Time.time >= nextFireTime)
        {
            StartCoroutine(Shoot());  // Call Shoot method with slight delay between bullets
            nextFireTime = Time.time + fireRate; // Set the next fire time
        }
    }

    IEnumerator Shoot()
    {
        // Loop through and shoot multiple bullets if necessary
        for (int i = 0; i < bulletsToShoot; i++)
        {
            // Instantiate the bullet at the fire point's position
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Set the bullet rotation explicitly to (90, 0, 0) if you want to enforce that rotation
            bullet.transform.rotation = Quaternion.Euler(90, 0, 0);  // Set rotation to (90, 0, 0)

            // Get the Rigidbody component of the bullet
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            // Make sure the bullet's velocity is set correctly and no other forces interfere with it
            rb.linearVelocity = Vector3.zero;  // Clear any existing velocity
            rb.isKinematic = false;  // Ensure the Rigidbody is not kinematic to interact with physics
            rb.useGravity = false;   // Disable gravity (if it's affecting the bullet)

            // Apply the force in the desired direction (firePoint.forward)
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.VelocityChange);

            // Wait for the bulletDelay before spawning the next bullet
            yield return new WaitForSeconds(bulletDelay);  // Slight delay between each bullet
        }
    }

    // Method to upgrade the gun's firepower
    public void UpgradeGun()
    {
        bulletsToShoot += 1; // Increase the number of bullets shot at once
    }
}
