using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private Vector3 spawnNourriturePos;
    public ParticleSystem particulesNourriture;
    private GameOverTrigger gameOverTrigger;

    public GameObject[] projectilesPrefabs;
    public int projectileIndex;

    private float speed = 10f;
    public float horizontalInput;
    public float limite = 12f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        gameOverTrigger = FindObjectOfType<GameOverTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        //Faire bouger le personnage
        horizontalInput = Input.GetAxis("Horizontal");

        if(!gameOverTrigger.IsGameOver())
        {
            if (gameObject.transform.position.x <= limite && gameObject.transform.position.x >= -limite)
                transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            else if (gameObject.transform.position.x > limite)
                transform.position = new Vector3(limite, 0, -25);
            else if (gameObject.transform.position.x < -limite)
                transform.position = new Vector3(-limite, 0, -25);
            //Faire spawner la nourriture
            SpawnBouffe();
        }
    }
    //Méthode pour faire spawner la nourriture
    void SpawnBouffe()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetTrigger("Tir_Trig");
            particulesNourriture.Play();
            int projectileIndex = Random.Range(0, projectilesPrefabs.Length);
            spawnNourriturePos = new Vector3(transform.position.x + 1, transform.position.y + 2, transform.position.z);
            Instantiate(projectilesPrefabs[projectileIndex], spawnNourriturePos, projectilesPrefabs[projectileIndex].transform.rotation);

        }
    }
}
