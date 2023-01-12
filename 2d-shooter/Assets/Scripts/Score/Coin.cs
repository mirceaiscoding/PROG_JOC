using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<ScoreManager>().ChangeScore(coinValue);
            other.gameObject.GetComponent<ItemDescriptionManager>().PrintCoinsValue(coinValue);
            Destroy(gameObject);
        }
    }
}
