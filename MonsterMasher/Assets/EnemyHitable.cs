using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitable : Hitable
{
    public List<AttackController> myAttacks = new List<AttackController>();
    [SerializeField]
    private int myHealth;
    private EnemyAnimationController myEnemyAnimator;
    public AnimationClip myHitClip;
    public bool hitstunned = false;

    private void OnEnable()
    {
        if (myEnemyAnimator == null)
        {
            myEnemyAnimator = gameObject.GetComponent<EnemyAnimationController>();
        }


    }

    public void EndHitStun()
    {
        hitstunned = false;
    }


    public override void GetHit(int damage)
    {
        //what to do when the enemy is hit

        if (hitstunned)
        {//dont get hit while hit stunned
            return;
        }

        //for every attack we have make sure we turn off its events as we are now going to override with being hit.
        foreach (AttackController item in myAttacks)
        {
            item.GotHit();
        }

        myHealth -= damage;
        hitstunned = true;

        if (myHealth > 0)
        {
            myEnemyAnimator.myAnimator.Play(myHitClip.name);

        }
        else
        {

            myEnemyAnimator.PlayDie();
        }


    }
}
