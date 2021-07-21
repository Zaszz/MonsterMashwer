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

    public Rigidbody2D playerRB;



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
        if (allowmove == false)
        {
            playerRB.velocity = new Vector2(0,0);
        }
    }

    private void CheckWalkAnimation()
    {
        float fart = Mathf.Abs(playerRB.velocity.x) + Mathf.Abs(playerRB.velocity.y);
        myController.myAnimator.SetFloat("MoveSpeed", fart);

        
    }

    public void CheckFacing(Vector2 vect)
    {
        if (vect.x > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        if (vect.x < 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    private void CalculateMovementVector()
    {
        x = Input.GetAxis("Horizontal") * horizontalspeed * Time.deltaTime;
        y = Input.GetAxis("Vertical") * verticalspeed * Time.deltaTime;
        CheckFacing(new Vector2(x,y));
        if (x + y == 0)
        {
            playerRB.velocity = new Vector2(0, 0);
        }
    }

    private void FixedUpdate()
    {
        if (allowmove)
        {
            CalculateMovementVector();
            
            CheckWalkAnimation();
            if (x != 0 || y != 0)
            {
                playerRB.velocity= new Vector2(x,y);
            }
            //player.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }
    }

}
