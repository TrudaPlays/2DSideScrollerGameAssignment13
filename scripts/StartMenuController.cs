using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*script to control the start menu*/
public class StartMenuController : MonoBehaviour
{
    public void OnStartClick()
    {
        // Load the next scene, which is the main game scene
        SceneManager.LoadScene("2DSideScroller");
    }

    public void OnExitClick()
    {
#if UNITY_EDITOR
        // If we're in the Unity Editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
