using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed at which the gun moves
    public float leftBoundary = -2f; // Leftmost position
    public float rightBoundary = 2f; // Rightmost position

    void Update()
    {
        // Get input from the A and D keys
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate the movement direction
        Vector3 movement = new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;

        // Move the gun left or right
        transform.Translate(movement);

        // Clamp the gun's position to the boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftBoundary, rightBoundary);
        transform.position = clampedPosition;
    }
}