using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
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
}
