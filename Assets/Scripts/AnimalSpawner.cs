using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    private float spawnRangeX = 10;
    private float spawnZ = -13;

    private float repeatDelay = 2f;
    private float nextDelay = 5f;
    private float progress;
    public Vector3 spawnPos;
    // Start is called before the first frame update
    void Start()
    {
        progress = 0f;
    }

    // Update is called once per frame
    void Update()
    {
         spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnZ);

        progress += Time.deltaTime;

        //Si le délai est atteint
        if (progress >= nextDelay)
        {
            //Spawner un obstacle et reset le progrès
            progress = 0f;
            SpawnAnimaux();

            //Prochain délai est aléatoire autour de repeatDelay
            nextDelay = Random.Range(0.85f * repeatDelay, 1.15f * repeatDelay);
        }

    }

    void SpawnAnimaux()
    {
        int index = Random.Range(0, objectPrefabs.Length);
        repeatDelay *= 0.99f;
        GameObject animal = objectPrefabs[index];
        Instantiate(animal, spawnPos, animal.transform.rotation);
    }
}
