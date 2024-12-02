using UnityEngine;
using UnityEngine.SceneManagement;
public class BorderScript : MonoBehaviour
{
    // Reference to the player GameObject
    [SerializeField]
    private GameObject player;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            // Reload the current scene when the player enters the trigger
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
