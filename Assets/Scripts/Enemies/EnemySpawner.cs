using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    // Enemy Settings
    [Header("Enemy Settings")]
    [SerializeField] private GameObject enemyPrefab; // The enemy prefab to spawn
    [SerializeField] private float spawnInterval = 3f; // Time between each spawn
    [SerializeField] private int baseEnemiesPerWave = 5; // Base number of enemies per wave
    [SerializeField] private float waveInterval = 10f; // Time between waves
    [SerializeField] private float spawnDistance = 10f; // Distance from the player to spawn enemies
    [SerializeField] private LayerMask terrainLayer; // The layer mask for terrain

    [Header("UI Settings")]
    [SerializeField] private TextMeshProUGUI waveNumberText; // Reference to the UI text to display the wave number

    private int currentWave = 0; // Track the current wave
    private Transform playerTransform; // Reference to the player's transform

    private EnemyAi enemyAi; // Reference to the enemy AI script

    private void Start()
    {
        playerTransform = Camera.main.transform; // Get the player's transform
        InvokeRepeating(nameof(SpawnWave), 0f, waveInterval); // Start spawning waves
    }

    private void SpawnWave()
    {
        currentWave++; // Increase wave count

        int enemiesThisWave = baseEnemiesPerWave + currentWave * 2; // Increase by 2 enemies per wave
        float healthMultiplier = 1 + (currentWave - 1) * 0.2f; // Scale health by 20% per wave
        float damageMultiplier = 1 + (currentWave - 1) * 0.05f; // Scale damage by 5% per wave

        // Update the wave number text in the UI
        if (waveNumberText != null)
        {
            waveNumberText.text = "Wave: " + currentWave;
        }
        else
        {
            Debug.LogWarning("WaveNumberText UI element not assigned.");
        }

        // Spawn the enemies in this wave
        for (int i = 0; i < enemiesThisWave; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition(); // Get a random spawn position

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Spawn the enemy
            Enemy enemyScript = newEnemy.GetComponent<Enemy>(); // Get the enemy script

            if (enemyScript != null)
            {
                // Set enemy health based on wave multiplier
                enemyScript.SetHealth(enemyScript.GetBaseHealth() * healthMultiplier);
                enemyScript.SetDamage(enemyScript.GetBaseDamage() * damageMultiplier);
            }

            // Optionally, adjust spawn interval based on wave progression
            float adjustedInterval = spawnInterval - (currentWave * 0.1f); // Decrease spawn interval
            adjustedInterval = Mathf.Max(adjustedInterval, 1f); // Ensure the spawn interval doesn't go below 1 second

            // Delay the spawn of each enemy
            Invoke(nameof(SpawnEnemy), spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Get a random direction from the player
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = 0; // Keep the spawn on the XZ plane
        randomDirection.Normalize();

        // Calculate the spawn position at a fixed distance away from the player
        Vector3 targetPosition = playerTransform.position + randomDirection * spawnDistance;

        // Raycast to ensure the spawn position is on the terrain
        RaycastHit hit;
        if (Physics.Raycast(targetPosition + Vector3.up * 50f, Vector3.down, out hit, Mathf.Infinity, terrainLayer))
        {
            // Return the position on the terrain surface
            return hit.point;
        }

        // Fallback if raycast fails
        return playerTransform.position + randomDirection * spawnDistance;
    }

    // Spawn a single enemy
    private void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition(); // Get a random spawn position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Spawn the enemy
    }
}
