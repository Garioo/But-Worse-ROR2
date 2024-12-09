using UnityEngine;
using UnityEngine.UI;
using TMPro;          

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Health Settings")]
    public float maxHealth = 275f;
    public float currentHealth;

    [Header("UI Elements")]
    public Slider healthSlider;  // Reference to the health bar
    public TextMeshProUGUI healthText;  // Reference to the health text

    void Start()
    {
        // Initialize player's health to max health at the start
        currentHealth = maxHealth;

        // Set initial values for UI elements
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        if (healthText != null)
        {
            UpdateHealthText();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        // Update both the health slider and health text
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (healthText != null)
        {
            UpdateHealthText();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death 
        Debug.Log("Player has died");
        gameObject.SetActive(false); //disable the player object
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);

        // Update both the health slider and health text
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (healthText != null)
        {
            UpdateHealthText();
        }
    }

    private void UpdateHealthText()
    {
        // Display health as an int"
        healthText.text = "Health: " + currentHealth.ToString("F0");
    }
}