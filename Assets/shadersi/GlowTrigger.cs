using UnityEngine;

public class GlowTrigger : MonoBehaviour
{
    public Material glowMaterial;
    private Material originalMaterial;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalMaterial = spriteRenderer.material;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.material = glowMaterial;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.material = originalMaterial;
            }
        }
    }
}
