using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    private Rigidbody foodRB;
    private float speed = 15f;
    private float topBound = -4.85f;
    private AnimalController animalController;
    // Start is called before the first frame update
    void Start()
    {
        foodRB = GetComponent<Rigidbody>();
        animalController = FindObjectOfType<AnimalController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z > topBound)
        {
            animalController.Manger();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
        }
    }
}
