using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    public Health playerHealth;

    private void OnEnable()
    {
        playerHealth.OnDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
