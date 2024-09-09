using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Animator playerAnim;
    private Vector3 spawnNourriturePos;
    private ParticleSystem particules;


    public GameObject[] projectilesPrefabs;
    public int projectileIndex;

    private float speed = 10f;
    public float horizontalInput;
    public float limiteDroite = 12;
    public float limiteGauche = -12;

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


        if (gameObject.transform.position.x <= limiteDroite && gameObject.transform.position.x >= limiteGauche)
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        else if (gameObject.transform.position.x > limiteDroite)
            transform.position = new Vector3(limiteDroite, 0,-25);
        else if(gameObject.transform.position.x < limiteGauche)
            transform.position = new Vector3(limiteGauche, 0, -25);
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
            spawnNourriturePos = new Vector3(transform.position.x, transform.position.y +2, transform.position.z);
            Instantiate(projectilesPrefabs[projectileIndex], spawnNourriturePos, projectilesPrefabs[projectileIndex].transform.rotation);
        }
    }
}
