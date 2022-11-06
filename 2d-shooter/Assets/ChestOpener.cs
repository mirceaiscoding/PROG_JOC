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

    /
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
        if (Input.GetKeyDown("E"))
        {
            if (ChestClose == true)
            {
                ChestClose.SetActive(false);
                ChestOpen.SetActive(true);
            }
            else
            {
                ChestClose.SetActive(true);
                ChestOpen.SetActive(false);
            }
        }
        /*
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Update variable for animator to switch between idle and running.
        animator.SetFloat("Speed", Mathf.Abs(moveX) + Mathf.Abs(moveY));

        // Flip player based on horizontal movement
        if (moveX > 0)
        {
            // normal
            spriteRenderer.flipX = false;
        }
        else if (moveX < 0)
        {
            // moving to the left -> flip
            spriteRenderer.flipX = true;
        }
        */
    }
    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        ChestClose.SetActive(false);
        ChestOpen.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        ChestClose.SetActive(true);
        ChestOpen.SetActive(false);
    }
    */
    
}
