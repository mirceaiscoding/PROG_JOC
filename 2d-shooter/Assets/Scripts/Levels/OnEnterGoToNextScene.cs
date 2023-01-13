using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnterGoToNextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            // increase the number of stages cleared by the player
            other.gameObject.GetComponent<ScoreManager>().levelCleared += 1;
            other.gameObject.GetComponent<ScoreManager>().levelClearedText.text = "Level: " + other.gameObject.GetComponent<ScoreManager>().levelCleared.ToString();

            // move to next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
