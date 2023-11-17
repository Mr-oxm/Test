using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
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

    // OnTriggerEnter2D is called when another collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the tag "Player"
        if (other.tag == "Player")
        {
            // If the entering collider is the player, set the current checkpoint in the LevelManager to this GameObject
            FindObjectOfType<LevelManager>().CurrentCheckpoint = this.gameObject;
        }
    }
}
