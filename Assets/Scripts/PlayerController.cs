using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private Vector3 spawnNourriturePos = new Vector3(0, 0, 0);
    public GameObject[] projectilesPrefabs;
    public int projectileIndex;

    private float speed = 10f;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Faire bouger le personnage
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        //Faire spawner la nourriture
        SpawnBouffe();

    }
    //Méthode pour faire spawner la nourriture
    void SpawnBouffe()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int projectileIndex = Random.Range(0, projectilesPrefabs.Length);
            playerAnim.SetTrigger("Tir_Trig");
            spawnNourriturePos = transform.position;
            Instantiate(projectilesPrefabs[projectileIndex], spawnNourriturePos, projectilesPrefabs[projectileIndex].transform.rotation);
        }
    }
}
