using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevelDoor : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeLevel();
    }

    public void ChangeLevel()
    {
        SceneManager.LoadScene("2DSideScroller");
    }
}
