using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    private GameOverManager gameOverManager;
    private UiController uiManager;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    void Start()
    {
        // Find the GameOverManager in the scene
        gameOverManager = FindObjectOfType<GameOverManager>();
        uiManager = FindObjectOfType<UiController>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene!");
        }
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player");
            // Load the "Ui" scene
            SceneManager.LoadScene("Ui", LoadSceneMode.Additive);

            rb.velocity = Vector2.zero;

            // Show the Lose Canvas and stop the game
            uiManager.ShowLoseCanvas();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle trigger events if necessary
    }
}


