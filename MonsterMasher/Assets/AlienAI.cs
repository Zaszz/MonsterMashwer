using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAI : MonoBehaviour
{
    public AttackController myAttack;
    public EnemyAnimationController myAnimator;
    public EnemyHitable myHitable;

    public float verticaldifferenceallowed = 2f;
    public float verticalspeed;
    public float horizontaldifferenceallowed = 2f;
    public float horizontalspeed;
    public Rigidbody2D myRb;

    public float delaytimemin = 1f;
    public float delaytimemax = 2f;
    private float timer = 0f;
    private float brakestimer = 0f;
    private float brakedelay = 1f;

    private void Update()
    {
        UpdateFacing();
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f  && myHitable.hitstunned == false)
        {
            DetermineAction();
            timer = Random.Range(delaytimemin, delaytimemax);
        }

        if (brakestimer > 0f)
        {
            brakestimer -= Time.deltaTime;
            if (brakestimer <= 0)
            {
                brakestimer = 0f;
                myRb.velocity = new Vector2(0, 0);
            }
        }
    }

    private void UpdateFacing()
    {
        if (PlayerManager.playerObject.transform.position.x < gameObject.transform.position.x)
        {
            FaceLeft();
        }
        else
        {
            FaceRight();
        }
    }

    private void DetermineAction()
    {


        if (PlayerManager.playerObject.transform.position.y < gameObject.transform.position.y  && gameObject.transform.position.y - PlayerManager.playerObject.transform.position.y >verticaldifferenceallowed)
        {
            //below us
            MoveDown();
            return;
        }

        if (PlayerManager.playerObject.transform.position.y > gameObject.transform.position.y && PlayerManager.playerObject.transform.position.y  - gameObject.transform.position.y > verticaldifferenceallowed)
        {
            //above us
            MoveUp();
            return;
        }

        if (PlayerManager.playerObject.transform.position.x < gameObject.transform.position.x && gameObject.transform.position.x - PlayerManager.playerObject.transform.position.x > horizontaldifferenceallowed)
        {
            //below us
            MoveLeft();
            return;
        }

        if (PlayerManager.playerObject.transform.position.x > gameObject.transform.position.x && PlayerManager.playerObject.transform.position.x - gameObject.transform.position.x  > horizontaldifferenceallowed)
        {
            //below us
            MoveRight();
            return;
        }

        Attack();



    }

    private void MoveUp()
    {
        myRb.velocity = new Vector2(0,verticalspeed);
        brakestimer = brakedelay;
    }

    private void MoveDown()
    {
        myRb.velocity = new Vector2(0, -verticalspeed);
        brakestimer = brakedelay;
    }

    private void MoveLeft()
    {
        myRb.velocity = new Vector2(-horizontalspeed, 0);
        brakestimer = brakedelay;
    }

    private void MoveRight()
    {
        myRb.velocity = new Vector2(horizontalspeed, 0);
        brakestimer = brakedelay;
    }

    private void  FaceLeft()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    private void FaceRight()
    {
        gameObject.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void Attack()
    {
        myAttack.BeginAttack();
    }
}
