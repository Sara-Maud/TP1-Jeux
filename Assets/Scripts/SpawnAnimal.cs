using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    public GameObject[] objectPrefabs;

    private Vector3 spawnPos = new Vector3(0, 0, 25);

    private float repeatDelay = 2f;
    private float nextDelay = 2f;
    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;

        //Si le d�lai est atteint
        if (progress >= nextDelay)
        {
            //Spawner un obstacle et reset le progr�s
            progress = 0f;
            SpawnObstacle();

            //Prochain d�lai est al�atoire autour de repeatDelay
            nextDelay = Random.Range(0.85f * repeatDelay, 1.15f * repeatDelay);
        }

    }

    void SpawnObstacle()
    {
        int index = Random.Range(0, objectPrefabs.Length);
        repeatDelay *= 0.99f;
        Instantiate(objectPrefabs[index], spawnPos, objectPrefabs[index].transform.rotation);
    }
}
