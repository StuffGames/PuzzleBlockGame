using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovementScript : MonoBehaviour
{
    //public List<CircleCollider2D> playerColliders = new List<CircleCollider2D>();
    public CircleCollider2D[] playerColliders = new CircleCollider2D[4];

    Transform playerT;

    public EdgeCollider2D wallCollider;
    private Vector3 pos;
    private Vector3 velTemp = Vector3.zero;
    public float speed = 0.125f;
    private bool buttonActive = false;
    private bool isTouchingTop = false;
    private bool isTouchingRight = false;
    private bool isTouchingBottom = false;
    private bool isTouchingLeft = false;

    private CircleCollider2D topCollider;
    private CircleCollider2D rightCollider;
    private CircleCollider2D bottomCollider;
    private CircleCollider2D leftCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerT = transform;
        pos = transform.position;

        playerColliders = GetComponents<CircleCollider2D>();

        int count = 0;

        foreach (CircleCollider2D col in playerColliders)
        {
            count++;
            //Debug.Log(count + " " + col.offset);
        }

        topCollider = playerColliders[0];
        rightCollider = playerColliders[1];
        bottomCollider = playerColliders[2];
        leftCollider = playerColliders[3];
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        /*if (moveX == 0)
        {
            buttonActive = false;
        }*/

        if (Input.GetKeyDown(KeyCode.D) && playerT.position == pos && isTouchingRight == false)
        {
            pos += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && playerT.position == pos && isTouchingBottom == false)
        {
            pos += Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.W) && playerT.position == pos && isTouchingTop == false)
        {
            pos += Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && playerT.position == pos && isTouchingLeft == false)
        {
            pos += Vector3.down;
        }

        /*if (moveX == 1 && playerT.position == pos)
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
        }*/

        transform.position = Vector3.SmoothDamp(playerT.position, pos, ref velTemp, speed);

        //transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        isTouchingTop = Physics2D.IsTouching(topCollider, wallCollider);
        isTouchingRight = Physics2D.IsTouching(rightCollider, wallCollider);
        isTouchingBottom = Physics2D.IsTouching(bottomCollider, wallCollider);
        isTouchingLeft = Physics2D.IsTouching(leftCollider, wallCollider);
    }

}
