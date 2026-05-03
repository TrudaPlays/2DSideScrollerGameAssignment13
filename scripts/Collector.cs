using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*this script handles the player collecting the gems*/
public class Collector : MonoBehaviour
{
    public PlayerSFX sfxscript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IItems item = collision.GetComponent<IItems>();
        if(item != null)
        {
            item.Collect();
            sfxscript.CollectSound();
        }
    }
}
