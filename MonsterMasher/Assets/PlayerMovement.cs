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
    public AnimationClip walkanimation;
    public PlayerAnimationController myController;
    public bool moving = false;
    public bool allowmove = true;

    private void OnEnable()
    {
        if (myController == null)
        {
            myController.GetComponentInParent<PlayerAnimationController>();
        }
    }

    public void AllowMove(bool boo)
    {
        allowmove = boo;
    }

    private void CheckWalkAnimation()
    {
        if (myController.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("AlienIdle") && moving)
        {
            myController.myAnimator.Play(walkanimation.name);
            myController.myAnimator.SetBool("Walking", true);
        }

        if (moving == false && myController.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("AlienWalk"))
        {
            myController.myAnimator.SetBool("Walking", false);
        }
    }

    

    private void Up()
    {
        if (Input.GetKey(KeyCode.W))
        {
            moving = true;
            y += verticalspeed * Time.deltaTime;
            if (y > toplimit)
                y = toplimit;
        }
    }

    private void Down()
    {
        if (Input.GetKey(KeyCode.S))
        {
            moving = true;
            y -= verticalspeed * Time.deltaTime;
        }
        if (y < bottomlimit)
            y = bottomlimit;
    }

    private void Left()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moving = true;
            x -= horizontalspeed * Time.deltaTime;
        }
        if (x < leftlimit)
            x = leftlimit;
    }

    private void Right()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moving = true;
            x += horizontalspeed * Time.deltaTime;
        }
        if (x > rightlimit)
            x = rightlimit;
    }

    private void Update()
    {
        if (allowmove)
        {
            moving = false;
            y = player.gameObject.transform.position.y;
            x = player.gameObject.transform.position.x;
            Up();
            Down();
            Left();
            Right();
            CheckWalkAnimation();
            player.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }
    }

}
