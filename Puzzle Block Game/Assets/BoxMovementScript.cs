using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovementScript : MonoBehaviour
{

    Transform playerT;

    private Vector3 pos;
    private Vector3 velTemp = Vector3.zero;
    public float speed = 0.125f;
    private bool buttonActive = false;

    // Start is called before the first frame update
    void Start()
    {
        playerT = transform;
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (moveX == 0)
        {
            buttonActive = false;
        }

        /*if (Input.GetKeyDown(KeyCode.D) && playerT.position == pos)
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
        }*/
        if (moveX == 1 && playerT.position == pos)
        {
            if (buttonActive == false)
            {
                buttonActive = true;
                pos += new Vector3(moveX, 0);
            }
        }
        else if (moveX == -1 && playerT.position == pos)
        {
            if (buttonActive == false)
            {
                buttonActive = true;
                pos += new Vector3(moveX, 0);
            }
        }

        transform.position = Vector3.SmoothDamp(playerT.position, pos, ref velTemp, speed);

        //transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
