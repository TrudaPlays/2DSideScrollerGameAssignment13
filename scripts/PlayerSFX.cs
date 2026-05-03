using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*controls all the sounds except for the level complete which the game controller does*/
public class PlayerSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip hurtSound;
    public AudioClip collectSound;
    public AudioClip deathSound;

    public void JumpSound()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void HurtSound()
    {
        audioSource.PlayOneShot(hurtSound);
    }

    public void CollectSound()
    {
        audioSource.PlayOneShot(collectSound);
    }

    public void DeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }
}
