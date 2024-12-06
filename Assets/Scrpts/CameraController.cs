using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform player; // Player's transform
    public float rotationSpeed = 3f; // Speed of camera rotation
    public float followSpeed = 10f; // Speed of camera following player
    public Vector3 offset = new Vector3(0, 1.5f, -0.5f); // Very close camera offset

    [Header("Rotation Limits")]
    public float minRotationX = 10f; // Min vertical rotation (down)
    public float maxRotationX = 60f; // Max vertical rotation (up)

    private float currentRotationX = 0f; // Current vertical rotation (pitch)
    private float currentRotationY = 0f; // Current horizontal rotation (yaw)

    void Update()
    {
        if (player == null) return;

        // Get mouse input for rotation
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Update horizontal and vertical rotation values
        currentRotationY += horizontalInput;
        currentRotationX -= verticalInput;
        currentRotationX = Mathf.Clamp(currentRotationX, minRotationX, maxRotationX); // Clamp vertical rotation

        // Apply the rotation
        Quaternion rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0);
        transform.rotation = rotation;

        // Calculate the target position (follow the player)
        Vector3 targetPosition = player.position + rotation * offset;

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Keep the camera looking at the player
        transform.LookAt(player.position + Vector3.up * 1.5f); // Adjust if needed for the player's height
    }
}
