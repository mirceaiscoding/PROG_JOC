using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1CoinSound : MonoBehaviour
{
    public AudioSource coinSound;

    // Play the sound when a coin is collected
    public void PlayCoinSound()
    {
        if (!coinSound.isPlaying)
        {
            coinSound.Play();
        }
    }
}
