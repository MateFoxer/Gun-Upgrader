using UnityEngine;
using TMPro;  // Import TextMeshPro namespace

public class BreakableWall : MonoBehaviour
{
    public int requiredHits = 100; // Number of hits required to break the wall
    public int currentHits = 0;    // Current number of hits
    public GameManager gameManager; // Reference to the GameManager script to trigger game over
    public TMP_Text scoreText;     // Reference to the TextMeshPro Text component

    private bool isDestroyed = false; // Flag to check if the wall has been destroyed

    void Start()
    {
        // Ensure GameManager is assigned in the Inspector
        if (gameManager == null)
        {
            Debug.LogError("GameManager is not assigned in BreakableWall!");
        }

        // Ensure scoreText is assigned in the Inspector
        if (scoreText == null)
        {
            Debug.LogError("Score Text is not assigned in BreakableWall!");
        }
        else
        {
            // Initialize score text (set it to 100 initially, for example)
            scoreText.text = "100";
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the wall was hit by a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Increment the hit counter when the wall is hit by a bullet
            currentHits++;

            // Update the displayed score (decrease by 1 each hit)
            UpdateScore();

            // Check if the wall has reached the required number of hits
            if (currentHits >= requiredHits)
            {
                BreakWall();
            }
        }
    }

    void BreakWall()
    {
        // Destroy the wall (or handle breaking the wall)
        isDestroyed = true;
        Destroy(gameObject);

        // Trigger game over when the wall is destroyed
        gameManager.TriggerGameOver();
    }

    void UpdateScore()
    {
        // Decrease the score displayed by 1 for each bullet hit
        if (scoreText != null)
        {
            int newScore = Mathf.Max(0, int.Parse(scoreText.text) - 1);  // Prevent negative scores
            scoreText.text = newScore.ToString(); // Update the text to display the new score
        }
    }

    // This method will check if the gun has passed the wall without destroying it
    void OnTriggerEnter(Collider other)
    {
        // If the gun enters the trigger and the wall isn't destroyed yet, trigger game over
        if (other.CompareTag("Player") && !isDestroyed)
        {
            gameManager.TriggerGameOver(); // Trigger game over since the gun passed without destroying the wall
        }
    }
}
