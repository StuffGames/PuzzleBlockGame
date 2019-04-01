using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovementScript : MonoBehaviour
{

    Transform playerT;

    private Vector3 pos;
    private float speed = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        playerT = transform;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && playerT.position == pos)
        {
            pos += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && playerT.position == pos)
        {
            pos += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.W) && playerT.position == pos)
        {
            pos += Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && playerT.position == pos)
        {
            pos += Vector3.down;
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
