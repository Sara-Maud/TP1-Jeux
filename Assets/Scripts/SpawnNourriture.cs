using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNourriture : MonoBehaviour
{
    public GameObject objectPrefabs;

    public GameObject player;

    private Vector3 spawnPos = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spawnPos = player.transform.position;
            SpawnBouffe();
        }
    }

    void SpawnBouffe()
    {
        Instantiate(objectPrefabs, spawnPos, objectPrefabs.transform.rotation);
    }
}
