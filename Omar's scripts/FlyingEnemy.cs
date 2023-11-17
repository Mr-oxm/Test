using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyController
{
    public float HorizontalSpeed;     // Speed at which the enemy moves horizontally
    public float VerticalSpeed;       // Speed at which the enemy moves vertically
    public float Amplitude;           // Amplitude of the vertical movement
    
    private Vector3 temp_position;  // Initial position of the enemy, used as a reference point
    // Start is called before the first frame update
    void Start()
    {
        temp_position = transform.position;  // Store the initial position for reference
    }

    // FixedUpdate is called at a fixed time interval, good for physics calculations
    void FixedUpdate()
    {
        // Use Mathf.PingPong to create a back-and-forth movement along the X-axis
        temp_position.x += HorizontalSpeed;

        // Calculate the vertical movement using the sine function
        temp_position.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * Amplitude;


        // Update the enemy's position
        transform.position = temp_position;
    }

}
