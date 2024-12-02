using UnityEngine;


public class Key : MonoBehaviour
{
    // Reference to the Door that this key will unlock
    [SerializeField] private Door door; 

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Notify the door that the player has found the key
            door.PlayerFoundKey();  
            // Destroy the key object after it has been collected
            Destroy(gameObject);   
        }
    }
}