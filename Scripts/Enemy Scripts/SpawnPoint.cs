using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedPoint : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        // Initialization code goes here if needed
    }

    // OnTriggerEnter2D is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the tag "Player"
        if (other.gameObject.tag == "Player")
        {
            // If the entering collider is the player, respawn the enemy using the RespawnEnemy method in the LevelManager
            FindObjectOfType<LevelManager>().RespawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Update code goes here if needed (empty in this case)
    }
}
