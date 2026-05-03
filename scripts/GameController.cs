using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*this controls everything heheheheh...not really but most of it:)*/
public class GameController : MonoBehaviour
{
    private static GameController instance;
    public PlayerSFX sfxscript;
    public PlayerHealth healthscript;

    int progressAmount;
    public Slider progressSlider; //shows how many gems r collected

    public GameObject player;
    public GameObject bouncingBug;
    public List<GameObject> gems;

    public GameObject levelCompleteDoor;
    public GameObject gameOverScreen;
    public GameObject reminderScreen;
    public GameObject congratsScreen;
    public TMP_Text gemsCollectedText;

    public AudioSource levelCompleteSound;

    public int gemsCollected;

    public static event Action OnReset;

    public float reminderDisplayDuration = 4f;//how long to display the reminder screen


    // Start is called before the first frame update
    void Start()
    {
        congratsScreen.SetActive(false);
        levelCompleteDoor.SetActive(false);
        reminderScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        progressAmount = 0;
        progressSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
        PlayerHealth.OnPlayerDied += GameOverScreen;
        Time.timeScale = 1.0f;
        ResetLevel();

    }

    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        sfxscript.DeathSound();
        gemsCollectedText.text = "You collected " + gemsCollected + " gem!";
        if(gemsCollected != 1)
        {
            gemsCollectedText.text = "You collected " + gemsCollected + " gems!";
        }
        Time.timeScale = 0f;
    }

    void Awake()
    {
        // Singleton pattern to prevent duplicates
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        congratsScreen.SetActive(false);
        gemsCollected = 0;
        Debug.Log("You are back at the beginning of the level!");
        ResetLevel();
        OnReset.Invoke();
        Time.timeScale = 1;
    }

    public void ResetLevel()
    {
        // Reset player position
        player.transform.position = new Vector3(5.95f, 3.36f, transform.position.z);
        bouncingBug.transform.position = new Vector3(16.49039f, 1.82f, transform.position.z);
        levelCompleteDoor.SetActive(false);
        healthscript.ResetHealth();

        // Reset gems so they are visible and collectable again
        for (int i = 0; i < gems.Count; i++)
        {
            GameObject gem = gems[i];
            gem.SetActive(true);
        }
        // Reset progress
        progressAmount = 0;
        progressSlider.value = 0;
    }

    public void LevelComplete()
    {
        Time.timeScale = 0f;
        congratsScreen.SetActive(true);
        levelCompleteSound.Play();

    }


    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        gemsCollected++;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
            Debug.Log("Level Complete!");
            Debug.Log("You collected " + gemsCollected + " gems!");
            showReminderScreen();
        }
    }

    //function starts the coroutine ShowReminder
    void showReminderScreen()
    {
        StartCoroutine(ShowReminderAndTurnOnDoor());
    }


    //coroutine to show the reminder screen for a specified amount of time
    IEnumerator ShowReminderAndTurnOnDoor()
    {
        levelCompleteDoor.SetActive(true);
        // 1. Turn the UI on
        reminderScreen.SetActive(true);

        // 2. Wait for the specified amount of seconds
        yield return new WaitForSeconds(reminderDisplayDuration);

        // 3. Turn the UI off
        reminderScreen.SetActive(false);
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
