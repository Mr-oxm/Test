// use Edge collider

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private SpriteRenderer sr;         // Reference to the SpriteRenderer component
    public Sprite explodedBlock;       // Sprite to be used when the brick is destroyed

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component from the GameObject
    }

    // Update is called once per frame
    void Update()
    {
        // Update code goes here if needed (empty in this case)
    }

    // OnCollisionEnter2D is called when this collider/rigidbody has begun touching another rigidbody/collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding GameObject has the tag "Player"
        // and if the point of contact is below the top of the brick (to determine if it's a downward collision)
        if (collision.gameObject.CompareTag("Player") && collision.GetContact(0).point.y < transform.position.y)
        {
            // Change the sprite to the explodedBlock sprite
            sr.sprite = explodedBlock;

            // Destroy the brick GameObject after a short delay (0.2 seconds)
            Destroy(gameObject, 0.2f);
        }
    }
}
