using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 2f;

    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2f;
        if (gameObject.CompareTag("Animal"))
            transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime, Space.World);
        //environnement
        if(gameObject.CompareTag("Environment"))
        {
            if (transform.position.z < startPos.z - repeatWidth)
            {
                transform.position = startPos;
            }
        }
    }
}
