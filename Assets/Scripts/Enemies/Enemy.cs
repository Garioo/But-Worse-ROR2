using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _health;
    private float _damage;
    private readonly float _baseHealth = 100f; // Base health value
    private readonly float _basedamage = 2f; // Damage value of the enemy
    private PlayerHealth playerHealth; // Reference to the player's health script

    // Called when the script instance is being loaded.
    // Initializes the enemy's health and finds the player object to reference the PlayerHealth component.
    private void Start()
    {
        SetHealth(_baseHealth); // Ensure that the enemy starts with the correct health

        // Assuming the player has a tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.LogError("PlayerHealth component not found on player.");
            }
        }
        else
        {
            Debug.LogError("Player object not found.");
        }
    }

    // Sets the health of the enemy.
    // param name="health": The amount of health to set for the enemy.
    public void SetHealth(float health)
    {
        _health = health;
    }

    // Sets the damage value of the enemy.
    // param name="damage": The amount of damage to set for the enemy.
    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    // Gets the base health value of the enemy.
    // returns: The base health value.
    public float GetBaseHealth()
    {
        return _baseHealth;
    }

    // Gets the base damage value of the enemy.
    // returns: The base damage value.
    public float GetBaseDamage()
    {
        return _basedamage;
    }

    // Called when the enemy takes damage.
    // param name="damage": The amount of damage to apply to the enemy.
    public void TakeDamage(float damage)
    {
        _health -= damage; // Reduce health by the damage amount

        if (_health <= 0)
        {
            Die();
        }
    }

    public void BitePlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(_damage); // Adjust the damage value as needed
        }
        else
        {
            Debug.LogError("playerHealth is not set.");
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject);
    }
}
