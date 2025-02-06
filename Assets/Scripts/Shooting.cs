using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign your bullet prefab in the Inspector
    public Transform firePoint;     // Assign the FirePoint GameObject here
    public float fireRate = 0.2f;   // Time between shots (in seconds)
    public float bulletForce = 20f; // Speed of the bullet

    private float nextFireTime = 0f; // Time when the next shot can be fired

    void Update()
    {
        // Check if it's time to fire again
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Set the next fire time
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the fire point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Apply force to the bullet in the direction the fire point is facing
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}