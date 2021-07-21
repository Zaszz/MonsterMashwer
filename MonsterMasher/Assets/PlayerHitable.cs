using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitable : Hitable
{
    public List<PlayerAttack> myAttacks = new List<PlayerAttack>();
    [SerializeField]
    private int myHealth;
    private PlayerAnimationController myPlayerAnimationController;
    public AnimationClip myHitClip;
    public bool hitstunned = false;

    private void OnEnable()
    {
        if (myPlayerAnimationController == null)
        {
            myPlayerAnimationController = gameObject.GetComponent<PlayerAnimationController>();
        }
    }

    public void EndHitStun()
    {
        hitstunned = false;
    }

    public override void GetHit(int damage)
    {
        //what to do when the enemy is hit

        //for every attack we have make sure we turn off its events as we are now going to override with being hit.
        foreach (PlayerAttack item in myAttacks)
        {
            item.GotHit();
        }

        myHealth -= damage;

        myPlayerAnimationController.myAnimator.Play(myHitClip.name);
        hitstunned = true;
    }
}
