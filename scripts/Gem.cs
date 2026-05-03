using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
/*the script to invoke the worth of a gem for the progress bar slider and to set the gem to inactive */
public class Gem : MonoBehaviour, IItems
{

    public static event Action<int> OnGemCollect;
    public int worth = 5;
    

    public void Collect()
    {
        OnGemCollect.Invoke(worth);

        gameObject.SetActive(false);
    }

}