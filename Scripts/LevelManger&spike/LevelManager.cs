using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint; // Reference to the current checkpoint GameObject
                                         // The player will respawn at this checkpoint when needed

    public Transform Enemy; // Reference to the enemy prefab that will be instantiated on respawn

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

    // RespawnPlayer is a public method that can be called to respawn the player at the current checkpoint
    public void RespawnPlayer()
    {
        // Find the PlayerController in the scene and set its position to the position of the current checkpoint
        FindObjectOfType<PlayerController>().transform.position = CurrentCheckpoint.transform.position;
    }

    // RespawnEnemy is a public method that can be called to respawn the enemy by instantiating a new one
    public void RespawnEnemy()
    {
        // Instantiate a new enemy at the position and rotation of the LevelManager
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}
