using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Method called on collision with other colliders
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "ball"
        if (collision.gameObject.CompareTag("ball"))
        {
            // Reset the position of the ball
            collision.gameObject.transform.position = new Vector3(0f, 0.3968f, 0f);
        }
    }
}
