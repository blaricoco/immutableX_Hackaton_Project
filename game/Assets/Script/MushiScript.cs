using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MushiScript : MonoBehaviour
{
    public float moveSpeed = 5f; // speed at which the enemy moves
    public float fleeThreshold = 5f; // distance at which the enemy should start fleeing from the player
    public float fleeDuration = 30f; // how long the enemy should flee for
    public GameObject player; // reference to the player GameObject

    private Vector3 targetPosition; // target position for the enemy to move towards
    private bool isFleeing = false; // flag to track whether the enemy is currently fleeing from the player
    private Vector3 velocity = Vector3.zero; // velocity for the SmoothDamp function
    private float fleeTimer = 0f; // timer for tracking the duration of the fleeing state

    void Start()
    {
        player =  GameObject.FindGameObjectsWithTag("Player")[0];
        // Set a random target position for the enemy to move towards
        targetPosition = RandomPosition();
    }

    void Update()
    {
        // Check if the enemy is too close to the player
        float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        if (distanceToPlayer < fleeThreshold)
        {
            // Start fleeing from the player
            isFleeing = true;
        }

        if (isFleeing)
        {
            // Flee from the player
            Vector3 fleeDirection = (this.transform.position - player.transform.position).normalized;
            this.transform.position = Vector3.SmoothDamp(this.transform.position, this.transform.position + fleeDirection, ref velocity, 0.1f, moveSpeed * 1.4f);

            // Increment the flee timer
            fleeTimer += Time.deltaTime;

            // Check if the flee timer has expired
            if (fleeTimer >= fleeDuration)
            {
                // Reset the flee timer
                fleeTimer = 0f;

                // Stop fleeing from the player
                isFleeing = false;

                // Set a new random target position
                targetPosition = RandomPosition();
            }
        }
        else
        {
            // Move towards the target position
            Vector3 moveDirection = (targetPosition - this.transform.position).normalized;
            this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, 0.1f, moveSpeed);

            // Check if the enemy has reached the target position
            if (Vector3.Distance(this.transform.position, targetPosition) < 0.1f)
            {
                // Set a new random target position
                targetPosition = RandomPosition();
            }
        }
    }

    // Generate a random position within a certain range
    Vector3 RandomPosition()
    {
        float x = Random.Range(-10f, 10f);
        float z = Random.Range(-10f, 10f);
        return new Vector3(x, 0f, z);
    }
}
