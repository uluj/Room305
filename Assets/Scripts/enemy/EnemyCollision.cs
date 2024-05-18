using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private GameOverManager gameOverManager;

    void Start()
    {
        // Find the GameOverManager in the scene
        gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager == null)
        {
            Debug.LogError("GameOverManager not found in the scene!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colllision from enemy");
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player");
            // Show the Game Over UI
            gameOverManager.ShowGameOverUI();
        }
    }
}
