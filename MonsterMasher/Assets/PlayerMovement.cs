using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float verticalspeed;
    public float horizontalspeed;
    public GameObject player;
    public float toplimit;
    public float bottomlimit;
    public float leftlimit;
    public float rightlimit;
    private float x;
    private float y;

    private void Up()
    {
        if (Input.GetKey(KeyCode.W))
        {
            y += verticalspeed * Time.deltaTime;
            if (y > toplimit)
                y = toplimit;
        }
    }

    private void Down()
    {
        if (Input.GetKey(KeyCode.S))
        {
            y -= verticalspeed * Time.deltaTime;
        }
        if (y < bottomlimit)
            y = bottomlimit;
    }

    private void Left()
    {
        if (Input.GetKey(KeyCode.A))
        {
            x -= horizontalspeed * Time.deltaTime;
        }
        if (x < leftlimit)
            x = leftlimit;
    }

    private void Right()
    {
        if (Input.GetKey(KeyCode.D))
        {
            x += horizontalspeed * Time.deltaTime;
        }
        if (x > rightlimit)
            x = rightlimit;
    }

    private void Update()
    {
        y = player.gameObject.transform.position.y;
        x = player.gameObject.transform.position.x;
        Up();
        Down();
        Left();
        Right();
        player.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }

}
