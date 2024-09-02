using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatEnvironment : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
