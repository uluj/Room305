using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeDirection : MonoBehaviour
{
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ChangeSpriteBasedOnInput();
    }

    void ChangeSpriteBasedOnInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W))
        {
            spriteRenderer.sprite = upSprite;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
        {
            spriteRenderer.sprite = downSprite;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.sprite = rightSprite;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.sprite = leftSprite;
            
        }
    }

}
