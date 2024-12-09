using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody _rigidbody;

    [Header("Bullet Settings")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float damage = 50f; // Damage value of the bullet

    // The BulletProjectile class is responsible for handling the behavior of a bullet, including its movement and interaction with targets.

    // Called when the script instance is being loaded.
    // Caches the Rigidbody component.
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("Rigidbody component missing.");
        }
    }

    // Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    // Sets the initial velocity of the bullet.
    private void Start()
    {
        _rigidbody.linearVelocity = transform.forward * speed; // Updated to .velocity to work better than linearVelocity
    }

    // Called when the Collider other enters the trigger.
    // Checks if the bullet hits a BulletTarget and deals damage if it does.
    // param name="other": The Collider that enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        BulletTarget target = other.GetComponent<BulletTarget>();

        if (target != null)
        {
            // Log the target hit and deal damage
            Debug.Log($"Bullet hit target: {other.name}");
            target.DealDamage(damage); // Pass the damage to the BulletTarget's DealDamage method
            Destroy(gameObject); // Destroy the bullet after hitting a target
        }
        else
        {
            Debug.Log($"Bullet hit something else.");
            Destroy(gameObject); // Destroy the bullet if it hits something other than a BulletTarget
        }
    }
}