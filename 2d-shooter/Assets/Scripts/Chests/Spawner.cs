using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] items; // list of prefabs for the items that you want to spawn

    public GameObject objectToSpawn;

    public GameObject spawnToObject;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objectToSpawn, spawnToObject.transform, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the chest has been opened
        if (!GetComponent<Animation>().isPlaying)
        {
            // play the chest opening animation
            GetComponent<Animation>().Play();

            // choose a random item from the list
            int index = Random.Range(0, items.Length);
            GameObject item = items[index];

            // instantiate the item at the chest's position
            Instantiate(item, transform.position, Quaternion.identity);
        }
    }
}
