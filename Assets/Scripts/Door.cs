using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The key that unlocks this door")]
    public GameObject key;
    private bool hasKey = false;
    [SerializeField]
    [Tooltip("Text to prompt the player about the door")]
    private TMP_Text doorText;
    [SerializeField]
    [Tooltip("Text to display when the player wins")]
    private TMP_Text winText;

      void Start()
    {
        winText.gameObject.SetActive(false);

        if (doorText != null)
        {
            doorText.text = "Find the key to open the door.";
        }
    }
    public void PlayerFoundKey()
    {
        hasKey = true;
        Debug.Log("Player found the key!");

        if (doorText != null)
        {
            doorText.text = "You can now open the door!";
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && hasKey)
        {
            OpenDoor();
            if (doorText != null)
            {
                doorText.text = "The door is now open!"; 
            }
        }
    }

    void OpenDoor()
    {
        Debug.Log("Door opened!");
        if (winText != null)
        {
            winText.text = "YOU WIN!";
        }
        winText.gameObject.SetActive(true);
        Time.timeScale = 0;
        
    }
}
