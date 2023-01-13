using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public event Action OnDamaged;
    public event Action OnDeath;

    public float health, maxHealth;

    public bool godMode = false;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            godMode = !godMode;
        }
    }

    public void TakeDamage(float amount)
    {
        if (!godMode || this.gameObject.tag != "Player")
        {
            health -= amount;
            OnDamaged?.Invoke();

            if (health <= 0)
            {
                // if an enemy dies, increase the number of enemies killed by the player
                if(this.gameObject.tag == "Enemy"){
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    // if the player is dead and an enemy dies after him, the score shoul not increase
                    if(player.GetComponent<Health>().health > 0){
                        player.GetComponent<ScoreManager>().enemiesKilled += 1;
                        player.GetComponent<ScoreManager>().enemiesKilledText.text = "Enemies: " + player.GetComponent<ScoreManager>().enemiesKilled.ToString();
                    }
                }

                // if the player dies, save the number of levels completed, enemies killed etc.
                if(this.gameObject.tag == "Player"){
                    this.gameObject.GetComponent<PreviousScore>().SetPreviousScores();
                }

                health = 0;
                Debug.Log("You're dead");
                OnDeath?.Invoke();
            }
        }
    }
}
