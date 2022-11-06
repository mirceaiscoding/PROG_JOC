using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpener : MonoBehaviour
{
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
        
    }

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
}
