using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyController
{
    public float HorizontalSpeed;     // Speed at which the enemy moves horizontally
    public float VerticalSpeed;       // Speed at which the enemy moves vertically
    public float Amplitude;           // Amplitude of the vertical movement
    private Vector3 initialPosition;  // Initial position of the enemy, used as a reference point
    public float MoveSpeed;           // Speed at which the enemy moves

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;  // Store the initial position for reference
    }

    // Update is called once per frame
    void Update()
    {
        // Consider adding any additional logic related to the enemy's behavior in Update
    }

    // FixedUpdate is called at a fixed time interval, good for physics calculations
    void FixedUpdate()
    {
        MoveEnemy();  // Call the method to move the enemy
    }

    // MoveEnemy is a private method that handles the enemy's movement logic
    private void MoveEnemy()
    {
        // Use Mathf.PingPong to create a back-and-forth movement along the X-axis
        float horizontalMovement = Mathf.PingPong(Time.time * HorizontalSpeed, 2 * MoveSpeed) - MoveSpeed;

        // Calculate the vertical movement using the sine function
        float verticalMovement = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;

        // Combine the movements to create the final position
        Vector3 newPosition = initialPosition + new Vector3(horizontalMovement, verticalMovement, 0f) * Time.fixedDeltaTime;

        // Update the enemy's position
        transform.position = newPosition;
    }

    // OnTriggerEnter2D is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // You might want to check if 'PlayerStats' is not null before calling 'TakeDamage'
            PlayerStats playerStats = FindObjectOfType<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);  // If the entering collider is the player, call the TakeDamage method in the PlayerStats script
            }
        }
    }
}
