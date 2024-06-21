using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Reference to the target points (waypoints)
    public GameObject pointA;
    public GameObject pointB;

    // Speed at which the enemy moves
    public float speed;

    // Rigidbody2D component for handling physics
    private Rigidbody2D rb;

    // The current target point the enemy is moving towards
    private Transform currentPoint;

    // Animator component for handling animations
    private Animator animator;

    // Threshold distance to determine if the enemy has reached the current point
    private float threshold = 0.1f;

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        // Initialize the current point to pointA at the start
        currentPoint = pointA.transform;
    }

    void FixedUpdate()
    {
        // Calculate the direction vector from the enemy's position to the current point, ignoring the y-value
        Vector2 direction = new Vector2(currentPoint.position.x - transform.position.x, 0).normalized;

        // Set the velocity of the Rigidbody2D to move the enemy towards the current point
        rb.velocity = direction * speed;

        // Set the "IsWalking" parameter in the Animator based on whether the enemy is moving
        animator.SetBool("IsWalking", rb.velocity.magnitude > 0);

        // Check if the enemy has reached the current point (within the threshold distance)
        if (Mathf.Abs(transform.position.x - currentPoint.position.x) < threshold)
        {
            // Switch the target point to the other point (toggle between pointA and pointB)
            if (currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }
            else
            {
                currentPoint = pointA.transform;
            }
        }
    }
}
