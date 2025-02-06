using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5f; // Time before the bullet is destroyed (if it doesn't hit anything)

    void Start()
    {
        // Destroy the bullet after a set time (in case it doesn't hit anything)
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet collided with a wall or another object
        if (collision.gameObject.CompareTag("Wall")) // Replace "Wall" with the appropriate tag
        {
            // Destroy the bullet when it hits the wall
            Destroy(gameObject);
        }
    }
}