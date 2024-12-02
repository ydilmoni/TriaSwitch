using UnityEngine;

public class Follower : MonoBehaviour
{
    // Target to follow (usually the player)
    [Tooltip("Assign your player here in the Inspector")]
    public Transform target;
    // Speed of the camera movement
    [Tooltip("Adjust for smoother camera motion")]
    public float smoothSpeed = 0.125f;
    // Offset for the camera position relative to the player
    [Tooltip("Define the desired camera position relative to the player")]
    public Vector3 offset;

    void LateUpdate()
    {
        // Check if the target is assigned
        if (target != null)
        {
            // Calculate the desired position based on the target's position and the offset
            Vector3 desiredPosition = target.position + offset;
            // Smoothly interpolate to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Ensure the camera remains fixed on its z-axis (useful for 2D setups)
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}