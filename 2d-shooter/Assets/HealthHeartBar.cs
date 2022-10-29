using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public float health, maxHealth;
    List<HealtHeart> hearts = new List<HealthHeart>();

    private void onEnable()
    {
        health += maxHealth;
    }

    private void onDisable()
    {
        health -= maxHealth;
    }

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();
        // determine how many hearts to make total
        // based off the max health
        float maxHealthRemainder = maxHealth % 2;
        int heartsToMake = (int)((maxHealth / 2) + maxHealthRemainder);
        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart(); // make total hearts needed
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(health - (i * 2), 0, 2);
            hearts[i].setHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        //heartComponent.setHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void ClearHearts() 
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
}

