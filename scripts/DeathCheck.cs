using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*this is attached to the death zone collider to make sure the player dies when they fall off of the ground Mario-style*/
public class DeathCheck : MonoBehaviour
{
    private GameController gameController;
    public GameObject bouncingBug;

    void Start()
    {
        // Find the GameController component in the scene
        gameController = GameObject.FindObjectOfType<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the door is the Player
        if (other.CompareTag("PlayerBlock"))
        {
            gameController.ResetLevel();
        }
        else if (other.CompareTag("Enemy"))
        {
            bouncingBug.transform.position = new Vector3(76.28f, 3.8f, transform.position.z);
        }
    }
}
