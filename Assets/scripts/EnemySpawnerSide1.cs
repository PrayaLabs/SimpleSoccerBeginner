using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnerSide1 : MonoBehaviour
{
    // Enemy prefab to spawn
    public GameObject enemyPrefab;

    // Number of enemies to spawn
    public int numberOfEnemies = 20;

    // Range for X and Z axes where enemies will be spawned
    public Vector2 xRange = new Vector2(-0.5f, 0.5f);
    public Vector2 zRange = new Vector2(-0.5f, 0.5f);

    // Spawn interval in seconds (also used for repositioning)
    public float repositionInterval = 1f;

    // Minimum distance between spawned enemies
    public float minimumDistance = 0.1f;

    // Array to store spawned enemies
    private GameObject[] spawnedEnemies;

    private void Start()
    {
        // Initialize the array to hold the spawned enemies
        spawnedEnemies = new GameObject[numberOfEnemies];

        // Spawn the enemies initially
        SpawnEnemies();

        // Start repositioning enemies at regular intervals
        StartCoroutine(RepositionEnemiesCoroutine());
    }

    // Function to spawn the enemies at random positions
    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 randomPosition;

            // Try to find a random position that satisfies the minimum distance condition
            do
            {
                randomPosition = new Vector3(
                    Random.Range(xRange.x, xRange.y), // X-axis range
                    0f,                              // Y-axis (ground level)
                    Random.Range(zRange.x, zRange.y)  // Z-axis range
                );
            }
            while (!IsPositionValid(randomPosition, i)); // Keep generating new positions until valid

            // Instantiate the enemy prefab and store it in the array
            spawnedEnemies[i] = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    // Check if the position is valid by ensuring the minimum distance from other enemies
    private bool IsPositionValid(Vector3 newPosition, int currentIndex)
    {
        for (int i = 0; i < currentIndex; i++)
        {
            if (spawnedEnemies[i] != null)
            {
                float distance = Vector3.Distance(spawnedEnemies[i].transform.position, newPosition);
                if (distance < minimumDistance)
                {
                    return false; // The new position is too close to an existing enemy
                }
            }
        }
        return true; // The new position is valid
    }

    // Coroutine to reposition enemies every second
    IEnumerator RepositionEnemiesCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(repositionInterval);

            // Reposition each enemy to a new random position
            for (int i = 0; i < spawnedEnemies.Length; i++)
            {
                if (spawnedEnemies[i] != null) // Check if the enemy exists
                {
                    Vector3 newRandomPosition;

                    // Try to find a random position that satisfies the minimum distance condition
                    do
                    {
                        newRandomPosition = new Vector3(
                            Random.Range(xRange.x, xRange.y), // X-axis range
                            0.3689f,                              // Y-axis (ground level)
                            Random.Range(zRange.x, zRange.y)  // Z-axis range
                        );
                    }
                    while (!IsPositionValid(newRandomPosition, i)); // Keep generating new positions until valid

                    // Update the position of the enemy
                    spawnedEnemies[i].transform.position = newRandomPosition;
                }
            }
        }
    }
}
