using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target; // Assign your player here in the Inspector
    public float smoothSpeed = 0.125f; // Adjust for smoother camera motion
    public Vector3 offset; // Use this to define the desired camera position relative to the player

    void LateUpdate()
    {
        if (target != null)
        {
            // Follow the player's position while maintaining the offset
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Ensure the camera remains fixed on its z-axis (useful for 2D setups)
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}