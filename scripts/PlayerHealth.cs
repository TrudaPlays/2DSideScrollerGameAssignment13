using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 This script controls the player's health, including taking damage,
updating the health UI and handling player death
 
 */
public class PlayerHealth : MonoBehaviour
{
    public PlayerSFX sfxscript;
    GameController controller;
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject player;

    public HealthUI healthUI;

    private SpriteRenderer spriteRenderer;

    public static event Action OnPlayerDied;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameController.OnReset += ResetHealth;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage(enemy.damage);
        }
    }
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        healthUI.SetMaxHearts(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthUI.UpdateHearts(currentHealth);
        //flash red
        StartCoroutine(FlashRed());

        sfxscript.HurtSound();

        if (currentHealth <= 0)
        {
            //player dead! -- call game over, animation etc...
            Debug.Log("You are dead!");
            OnPlayerDied.Invoke();
        }
    }

    private IEnumerator FlashRed()
    {
        Debug.Log("You got hurt!");
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }
}
