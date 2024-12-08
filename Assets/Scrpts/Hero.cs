using UnityEngine;
using StarterAssets;

public class Hero : MonoBehaviour
{
    public float health = 100;
    public float damage = 10;
    public float attackSpeed = 1;
    public float attackRange = 1;
    public float moveSpeed = 1;
    public float armor = 0;

    public GameObject magicBallPrefab; // Reference to the MagicBall prefab
    public Transform magicBallSpawnPoint; // Reference to the spawn point of the MagicBall
    public float magicBallSpeed = 10f; // Speed of the MagicBall

    private StarterAssetsInputs _input;
    private Camera _mainCamera;

    private void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
        if (_input == null)
        {
            Debug.LogError("StarterAssetsInputs component missing.");
        }

        _mainCamera = Camera.main;
        if (_mainCamera == null)
        {
            Debug.LogError("Main Camera not found.");
        }
    }

    private void Update()
    {
        // Check if the primary skill input is pressed and shoot the magic ball
        if (_input.PrimarySkill)
        {
            ShootMagicBall();
            _input.PrimarySkill = false; // Reset the input
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage * (1 - armor / 100);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void ShootMagicBall()
    {
        if (magicBallPrefab != null && magicBallSpawnPoint != null && _mainCamera != null)
        {
            // Perform a raycast from the center of the screen
            Ray ray = _mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                targetPoint = hit.point;
            }
            else
            {
                targetPoint = ray.GetPoint(1000); // Arbitrary large distance
            }

            Vector3 direction = (targetPoint - magicBallSpawnPoint.position).normalized;

            GameObject magicBall = Instantiate(magicBallPrefab, magicBallSpawnPoint.position, Quaternion.identity);
            Rigidbody rb = magicBall.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = direction * magicBallSpeed;
            }
        }
    }
}