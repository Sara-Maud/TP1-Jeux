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
    public bool isOnLimit = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (!isOnLimit)
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnNourriturePos = transform.position;
            SpawnBouffe();
        }
    }
    void SpawnBouffe()
    {
        Instantiate(objectPrefabs, spawnNourriturePos, objectPrefabs.transform.rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnLimit = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnLimit = false;
    }
}
