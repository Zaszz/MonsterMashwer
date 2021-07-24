using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [Header("Use this Component for Punch Attacks")]
    [Header("Only For Enemies")]
    private EnemyAnimationController myEnemyAnimator;
    public AnimationClip myAnimation;
    public int damage;
    public Collider2D myCollider;
    public bool hitbox = false;
    public GameObject hitBoxObject;
    public AudioSource source;
    

    private void OnEnable()
    {
        if (myEnemyAnimator == null)
        {
            myEnemyAnimator = gameObject.GetComponent<EnemyAnimationController>();
        }
    }

    //gets called by any function that wants to start the attack animation
    public void BeginAttack()
    {
        source.Play();
        myEnemyAnimator.myAnimator.Play(myAnimation.name);
    }

    

    //gets called only through animation events.
    public void ActivatePunchHitBox()
    {
        hitbox = true;
        hitBoxObject.SetActive(true);
    }

    //gets called only through the end animation event
    public void DeActivatePunchHitBox()
    {
        hitbox = false;
        hitBoxObject.SetActive(false);
    }

    //called if our attack got interupted because we got hit.
    public void GotHit()
    {
        hitbox = false;
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hitable hit = collision.gameObject.GetComponentInParent<Hitable>();
        EnemyHitable phitcheck = collision.gameObject.GetComponentInParent<EnemyHitable>();//double check we are not hitting an enemy, no friendly fire.

        if (hitbox && hit != null && phitcheck == null)
        {
            //we hit something hitable
            hit.GetHit(damage);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }
    */

}
