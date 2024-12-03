using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The key that unlocks this door")]
    public GameObject key;// Reference to the key GameObject
    private bool hasKey = false;// Tracks whether the player has the key
    [SerializeField]
    [Tooltip("Text to prompt the player about the door")]// Text component to display messages about the door
    private TMP_Text doorText;
    [SerializeField]
    [Tooltip("Text to display when the player wins")] // Text component to display the win message
    private TMP_Text winText;

    void Start()
    {
        winText.gameObject.SetActive(false);// Initially hide the win text

        if (doorText != null)
        {
            doorText.text = "Find the key to open the door."; // Prompt the player to find the key
        }
    }
    public void PlayerFoundKey()
    {
        hasKey = true;// Set hasKey to true when the player finds the key
        Debug.Log("Player found the key!");
        if (doorText != null)
        {
            doorText.text = "You can now open the door!";// Update the door text to inform the player
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the player collides with the door and has the key
        if (collider.CompareTag("Player") && hasKey)
        {
            OpenDoor();
            if (doorText != null)
            {
                doorText.text = "The door is now open!"; // Update the door text to inform the player
            }
        }
    }

    void OpenDoor()
    {
        Debug.Log("Door opened!");
        if (winText != null)
        {
            winText.text = "YOU WIN!";// Update the win text to inform the player
        }
        winText.gameObject.SetActive(true);// Show the win text
        Time.timeScale = 0;// Pause the game
        
    }
}
