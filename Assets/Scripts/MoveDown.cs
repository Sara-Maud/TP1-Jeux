using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private float speed = 1.5f;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(new Vector3(1,0,1) * speed * Time.deltaTime);
    }
}
