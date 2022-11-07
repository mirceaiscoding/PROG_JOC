using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
    /*
    public bool isOpen;
    public Animator animator;

    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("Chest now open...");
            animator.SetBool("IsOpen", isOpen);
        }
    }
    */

    // Distance from which the player can open and close the chest
    public float interactionDistance = 3f;

    public GameObject Player;
    
    public GameObject ChestClose, ChestOpen;


    // Start is called before the first frame update
    void Start()
    {
        ChestClose.SetActive(true);
        ChestOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Vector2.Distance(Player.transform.position, transform.position) < interactionDistance
            && Input.GetKeyDown(KeyCode.E))
        {
            if (ChestClose.activeSelf)
            {
                // close chest
                ChestClose.SetActive(false);
                ChestOpen.SetActive(true);
            }
            else
            {
                // open chest
                ChestClose.SetActive(true);
                ChestOpen.SetActive(false);
            }
        }

    }
}
