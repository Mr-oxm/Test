using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemy : EnemyController
{
    private PlayerController Player;  // Reference to the PlayerController for tracking the player
    public float speedtowardplayer;   // Speed at which the enemy moves towards the player

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>();  // Find and assign the PlayerController in the scene
    }

    // Update is called once per frame
    void Update()
    {
        // Move the enemy towards the player's position using Vector3.MoveTowards
        // This ensures the enemy follows the player at a constant speed
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speedtowardplayer * Time.deltaTime);
    }
}
