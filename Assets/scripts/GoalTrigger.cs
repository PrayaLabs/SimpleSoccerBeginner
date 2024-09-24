using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.SceneManagement; // For scene management
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    // Static variable to keep track of the shared goal count
    private static int goalCount = 0;

    // Reference to the TextMeshPro component
    public TextMeshProUGUI goalText;

    // Method called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggered object is tagged as "ball"
        if (other.CompareTag("ball"))
        {
            // Increment the goal count
            goalCount++;

            // Update the TextMeshPro UI element with the new goal count
            UpdateGoalText();

            // Check if the goal count is 10
            if (goalCount >= 10)
            {
                // Switch to the Cheer_Scene
                SceneManager.LoadScene("Cheer_Scene");
            }
            else
            {
                // Reset the position of the ball
                ResetBallPosition(other.gameObject);
            }
        }
    }

    // Method to update the goal text
    private void UpdateGoalText()
    {
        // Set the text to the current goal count
        goalText.text = $"Goal: {goalCount}";
    }

    // Method to reset the ball's position
    private void ResetBallPosition(GameObject ball)
    {
        ball.transform.position = new Vector3(0f, 0.3968f, 0f);
    }
}
