using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*changes the level or actually just resets this level as I have only one level in this game!*/
public class doorChangeLevel : MonoBehaviour
{

    private GameController gameController;

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
            gameController.LevelComplete();
        }
    }
}
