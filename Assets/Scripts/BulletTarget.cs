using UnityEngine;

public class BulletTarget : MonoBehaviour
{
    private Enemy _enemy;

    // The BulletTarget class is responsible for handling damage dealt to an enemy when hit by a bullet.

    // Called when the script instance is being loaded.
    // Caches the Enemy component to avoid repeated GetComponent calls.
    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    // Deals damage to the enemy.
    // param name="damage": The amount of damage to deal to the enemy.
    public void DealDamage(float damage)
    {
        if (_enemy != null)
        {
            // Call the TakeDamage method on the Enemy to apply damage
            _enemy.TakeDamage(damage);
        }
        else
        {
            Debug.LogWarning("No Enemy component found on target!");
        }
    }
}