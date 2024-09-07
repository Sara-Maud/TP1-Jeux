using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;

    public GameObject objectPrefabs;

    private Vector3 spawnNourriturePos = new Vector3(0, 0, 0);

    private float speed = 10f;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Faire bouger le personnage
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        //Faire spawner la nourriture
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnNourriturePos = transform.position;
            SpawnBouffe();
        }
    }
    //Méthode pour faire spawner la nourriture
    void SpawnBouffe()
    {
        Instantiate(objectPrefabs, spawnNourriturePos, objectPrefabs.transform.rotation);
    }
}
