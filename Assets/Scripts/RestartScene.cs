using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        // טוען מחדש את הסצנה הנוכחית
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
