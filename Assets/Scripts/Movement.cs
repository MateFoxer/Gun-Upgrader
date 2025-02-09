using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public float moveSpeed = 10f; // Speed at which the gun moves left and right
    public float forwardSpeed = 5f; // Default forward speed
    public float speedBoostMultiplier = 2f; // Multiplier for increased speed when holding W
    public float leftBoundary = -2f; // Leftmost position
    public float rightBoundary = 2f; // Rightmost position

    void Update()
    {
        // Get input from the A and D keys for left/right movement
        float moveInput = Input.GetAxis("Horizontal");

        // Move the gun left or right based on input
        Vector3 movement = new Vector3(moveInput, 0, 0) * moveSpeed * Time.deltaTime;

        // Check if the player is holding W to increase the forward speed
        if (Input.GetKey(KeyCode.W))
        {
            // Increase forward speed when W is held
            transform.Translate(Vector3.forward * forwardSpeed * speedBoostMultiplier * Time.deltaTime);
        }
        else
        {
            // Move forward with normal speed when W is not held
            transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        }

        // Apply horizontal movement and clamp the gun's position to the boundaries
        transform.Translate(movement);

        // Ensure the gun stays within the horizontal boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, leftBoundary, rightBoundary);
        transform.position = clampedPosition;
    }
}
