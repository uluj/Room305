using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public static UiController Instance { get; private set; }

    public Canvas loseCanvas; // Reference to the Lose Canvas
    public Canvas startCanvas; // Reference to the Start Canvas
    public Canvas winCanvas; // Reference to the Win Canvas
    void Start()
    {
        // Initially hide all canvases
       /* if (loseCanvas != null)
            loseCanvas.gameObject.SetActive(false);

        if (startCanvas != null)
            startCanvas.gameObject.SetActive(false);

        if (winCanvas != null)
            winCanvas.gameObject.SetActive(false);*/
    }
    void Awake()
    {
        // Singleton pattern to ensure only one instance of UIManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ShowLoseCanvas()
    {
        if (loseCanvas != null)
        {
            loseCanvas.gameObject.SetActive(true);
            Debug.Log("Lose Canvas shown");
        }
    }

    public void ShowStartCanvas()
    {
        if (startCanvas != null)
        {
            startCanvas.gameObject.SetActive(true);
            Debug.Log("Start Canvas shown");
        }
    }

    public void ShowWinCanvas()
    {
        if (winCanvas != null)
        {
            winCanvas.gameObject.SetActive(true);
            Debug.Log("Win Canvas shown");
        }
    }

}
