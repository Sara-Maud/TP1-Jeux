using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnvironnement : MonoBehaviour
{
    private float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);
    }
}
