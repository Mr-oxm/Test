using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFacingRight = false;  // Flag indicating whether the enemy is facing right or not
    public float maxSpeed = 3f;         // Maximum movement speed of the enemy
    public int damage = 6;              // Amount of damage the enemy inflicts on the player

    // Flip is a public method that reverses the direction the enemy is facing
    public void Flip()
    {
        isFacingRight = !isFacingRight;  // Toggle the value of isFacingRight
        // Flip the enemy's sprite by adjusting the local scale in the x-axis
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    // OnTriggerEnter2D is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the tag "Player"
        if (other.tag == "Player")
        {
            // If the entering collider is the player, call the TakeDamage method in the PlayerStats script
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code goes here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update code goes here if needed (empty in this case)
    }
}
