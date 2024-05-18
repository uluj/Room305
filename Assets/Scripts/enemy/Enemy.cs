using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // Speed at which the enemy follows the player
    public float stoppingDistance = 1f; // Distance at which the enemy stops following the player
    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player GameObject by tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("Player found: " + player.name);
    }

    void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        

        // Check if the enemy should move towards the player
        if (distanceToPlayer > stoppingDistance)
        {
            // Calculate the direction from the enemy to the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Log the direction
            Debug.Log("Direction to player: " + direction);

            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;

            // Log the enemy's new position
            
        }
    }
}
