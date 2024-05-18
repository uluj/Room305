using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public Canvas gameOverCanvas; // Reference to the Game Over UI Canvas

    void Start()
    {
        if (gameOverCanvas == null)
        {
            Debug.LogError("GameOver Canvas is not assigned in the inspector!");
            return;
        }

        // Initially hide the Game Over UI
        gameOverCanvas.enabled = false;
    }

    public void ShowGameOverUI()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.enabled = true;
            Debug.Log("Game Over UI shown");
        }
        else
        {
            Debug.LogError("GameOver Canvas is not assigned!");
        }
    }
}
