using UnityEngine;

public class ThirdPersonAiming : MonoBehaviour
{
    [Header("References")]
    public Transform playerBody;  // Reference to the player's body (for rotation)
    public Transform upperBody;  // Reference to the upper body or aiming pivot
    public Animator animator;  // Animator for the character
    public Camera playerCamera;  // Camera to calculate aiming direction

    [Header("Settings")]
    public float sensitivity = 100f;  // Mouse sensitivity
    public float verticalClamp = 45f;  // Maximum up/down rotation (vertical look angle)
    public float smoothTime = 0.1f;  // Smooth transition time for rotations
    public float rotationSpeed = 10f;  // Speed of the character's rotation to face the mouse position

    private float xRotation = 0f;  // Vertical rotation
    private float yRotation = 0f;  // Horizontal rotation (yaw)
    private float currentRotationVelocity;
    private Vector3 aimDirection;  // Direction to aim at

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Lock the mouse cursor to the center of the screen
        Cursor.visible = false;  // Hide the cursor for immersion
    }

    void Update()
    {
        HandleMouseInput();
        UpdateAnimatorParameter();
        AimAtMousePosition();
    }

    void HandleMouseInput()
    {
        // Get mouse input for vertical movement (up/down) and horizontal (left/right)
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Adjust vertical rotation and clamp it to avoid excessive look-up/down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalClamp, verticalClamp);

        // Adjust horizontal rotation (yaw), allowing the character to rotate with the mouse horizontally
        yRotation += mouseX;

        // Smoothly interpolate the rotation values to avoid abrupt movements
        float smoothedRotationX = Mathf.SmoothDamp(upperBody.localRotation.eulerAngles.x, xRotation, ref currentRotationVelocity, smoothTime);
        float smoothedRotationY = Mathf.SmoothDampAngle(playerBody.eulerAngles.y, yRotation, ref currentRotationVelocity, smoothTime);

        // Apply the smoothed rotations to the upper body and player body
        if (upperBody != null)
        {
            upperBody.localRotation = Quaternion.Euler(smoothedRotationX, 0f, 0f);  // Vertical (pitch) rotation
        }

        if (playerBody != null)
        {
            playerBody.rotation = Quaternion.Euler(0f, smoothedRotationY, 0f);  // Horizontal (yaw) rotation
        }
    }

    void AimAtMousePosition()
    {
        // Raycast from the camera to the mouse position in 3D space
        Ray ray = playerCamera.ScreenPointToRay(new Vector2(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2));

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            aimDirection = (hit.point - transform.position).normalized;  // Calculate direction to the hit point
        }
        else
        {
            aimDirection = ray.direction;  // If no hit, aim forward in the direction the camera is facing
        }

        // Ignore vertical axis for horizontal aiming to keep the body facing the right direction
        aimDirection.y = 0f;

        // Smoothly rotate the body to face the target direction (the aim direction)
        Quaternion targetRotation = Quaternion.LookRotation(aimDirection);
        playerBody.rotation = Quaternion.Lerp(playerBody.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }

    void UpdateAnimatorParameter()
    {
        // Set animator parameter for vertical aiming (optional for vertical animation blending)
        if (animator != null)
        {
            animator.SetFloat("AimVertical", xRotation / verticalClamp);
        }
    }
}
