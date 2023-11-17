using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;                 // Speed at which the player moves horizontally
    public float jumpHeight;                // Height of the player's jump
    public KeyCode Spacebar;                // Keycode for the jump action
    public KeyCode L;                       // Keycode for moving left
    public KeyCode R;                       // Keycode for moving right
    public Transform groundcheck;           // Transform representing the ground check position
    public float groundCheckRadius;         // Radius of the circle used for ground checking
    public LayerMask whatIsGround;          // Layer mask for identifying what is considered ground
    private bool grounded;                  // Flag indicating whether the player is grounded
    private Animator anim;                  // Reference to the Animator component for animation control

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   // Get the Animator component from the player GameObject
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the jump key is pressed and the player is grounded
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();  // Call the Jump method
        }

        // Check if the left movement key is held down
        if (Input.GetKey(L))
        {
            // Move the player to the left with a velocity of '-moveSpeed'
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            // Flip the player's sprite horizontally if it has a SpriteRenderer component
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        // Check if the right movement key is held down
        if (Input.GetKey(R))
        {
            // Move the player to the right with a velocity of 'moveSpeed'
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            // Flip the player's sprite horizontally if it has a SpriteRenderer component
            if (GetComponent<SpriteRenderer>() != null)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        // Update animator parameters based on player's velocity and grounded status
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);
    }

    // Jump is a method that handles the player's jump
    void Jump()
    {
        // Set the player's vertical velocity to achieve the specified jump height
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    // FixedUpdate is called at a fixed time interval, good for physics calculations
    void FixedUpdate()
    {
        // Perform a circle overlap check to determine if the player is grounded
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
    }
}
