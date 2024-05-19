using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    private GameOverManager gameOverManager;
    private UiController uiManager;

    void Start()
    {
        // Find the GameOverManager in the scene
        gameOverManager = FindObjectOfType<GameOverManager>();
        uiManager = FindObjectOfType<UiController>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player");

            // Load the "Ui" scene
            SceneManager.LoadScene("Ui", LoadSceneMode.Additive);

            // Show the Lose Canvas after the "Ui" scene is loaded
            StartCoroutine(ShowLoseCanvasAfterSceneLoad());
        }
    }

    IEnumerator ShowLoseCanvasAfterSceneLoad()
    {
        // Wait until the "Ui" scene is loaded
        while (SceneManager.GetSceneByName("Ui").isLoaded == false)
        {
            yield return null;
        }

        // Find the UIManager in the newly loaded scene
        uiManager = FindObjectOfType<UiController>();
        if (uiManager != null)
        {
            uiManager.ShowLoseCanvas();
        }
        else
        {
            Debug.LogError("UIManager not found in the Ui scene!");
        }
    }
}
