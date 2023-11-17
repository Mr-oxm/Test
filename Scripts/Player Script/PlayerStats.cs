using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 6;                   // Player's health
    public int lives = 3;                    // Number of lives the player has
    private float flickerTime = 0f;          // Timer for sprite flickering during immunity
    public float flickerDuration = 0.1f;     // Duration of sprite flickering
    private SpriteRenderer SpriteRenderer;   // Reference to the SpriteRenderer component
    public bool isImmune = false;            // Flag indicating whether the player is immune to damage
    private float ImmunityTime = 0f;         // Timer for immunity duration
    public float ImmunityDuration = 1.5f;    // Duration of immunity after taking damage
    public int coinsCollected = 0;           // Number of coins collected by the player

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();  // Get the SpriteRenderer component
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is immune to damage
        if (this.isImmune == true)
        {
            SpriteFlicker();  // Call method to make the sprite flicker
            ImmunityTime = ImmunityTime + Time.deltaTime;  // Update the immunity timer

            // Check if the immunity duration has passed
            if (ImmunityTime >= ImmunityDuration)
            {
                this.isImmune = false;          // Disable immunity
                this.SpriteRenderer.enabled = true;  // Ensure the sprite is visible
            }
        }
    }

    // SpriteFlicker is a method that makes the player's sprite flicker during immunity
    void SpriteFlicker()
    {
        // Check if the flicker time is less than the flicker duration
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        // If flicker duration is reached, toggle the sprite visibility
        else if (this.flickerTime >= this.flickerDuration)
        {
            SpriteRenderer.enabled = !(SpriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    // TakeDamage is a public method that handles player taking damage
    public void TakeDamage(int damage)
    {
        // Check if the player is not immune to damage
        if (this.isImmune == false)
        {
            this.health = this.health - damage;  // Reduce player's health by the specified damage amount

            // Ensure health does not go below zero
            if (this.health < 0)
                this.health = 0;

            // Check if the player has lives remaining and health is depleted
            if (this.lives > 0 && this.health == 0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();  // Respawn the player using LevelManager
                this.health = 6;  // Reset health
                this.lives--;     // Decrement lives
            }
            // Check if the player has no lives and health is depleted
            else if (this.lives == 0 && this.health == 0)
            {
                Debug.Log("Gameover");  // Log game over message
                Destroy(this.gameObject);  // Destroy the player GameObject
            }

            Debug.Log("Playe Health:" + this.health.ToString());  // Log player's health
            Debug.Log("Player Lives:" + this.lives.ToString());   // Log player's remaining lives
        }

        PlayHitReaction();  // Call method to initiate hit reaction (immunity)
    }

    // PlayHitReaction is a private method that initiates the hit reaction (immunity)
    void PlayHitReaction()
    {
        this.isImmune = true;      // Set the player to be immune
        this.ImmunityTime = 0f;    // Reset the immunity timer
    }
}
