using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour
{
    private Rigidbody foodRB;
    private float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        foodRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
           transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.CompareTag("Animal")) {
            Destroy(gameObject);
        //}
    }
}
