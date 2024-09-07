using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour
{
    private Rigidbody foodRB;
    private float speed = 4f;
    private float p = 5f;
    // Start is called before the first frame update
    void Start()
    {
        foodRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if(transform.position.z > p)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Animal")) {
            Destroy(gameObject);
        }
    }
}
