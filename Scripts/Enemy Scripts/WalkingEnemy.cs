using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialization code goes here if needed
    }

    // FixedUpdate is called at a fixed time interval, good for physics calculations
    void FixedUpdate()
    {
        // Check the direction the enemy is facing
        if (this.isFacingRight == true)
        {
            // Move the enemy to the right with a velocity of 'maxSpeed'
            this.GetComponent<Rigidbody2D>().velocity =
                new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            // Move the enemy to the left with a velocity of '-maxSpeed'
            this.GetComponent<Rigidbody2D>().velocity =
               new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    // OnTriggerEnter2D is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the entering collider has the tag "Wall" or "Enemy"
        if (collider.tag == "Wall" || collider.tag == "Enemy")
        {
            // If the collider is a wall or another enemy, flip the direction the enemy is facing
            Flip();
        }
        // Check if the entering collider has the tag "Player"
        else if (collider.tag == "Player")
        {
            // If the collider is the player, inflict damage and then flip the direction the enemy is facing
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();
        }
    }
}
