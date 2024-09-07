using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 1.5f;

    private PlayerController playerControllerScript;

    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2f;
        if (gameObject.CompareTag("Animal"))
            transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Animal"))
            transform.Translate(new Vector3(1, 0, 1) * speed * Time.deltaTime);
        //environnement
        else if(gameObject.CompareTag("Environment"))
        {
            transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);
            if (transform.position.z < startPos.z - repeatWidth)
            {
                transform.position = startPos;
            }
        }
    }
}
