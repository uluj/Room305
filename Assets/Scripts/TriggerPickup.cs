using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPickup : MonoBehaviour
{
    // Specify the tag for the key object
    public string keyTag = "Key";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Triggered");

        // Check if the collided object has the specified tag
        if (collision.gameObject.CompareTag(keyTag))
        {
            Debug.Log("Key picked up");
            // Destroy the key object
            Destroy(collision.gameObject);
        }
    }
}
