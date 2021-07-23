using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Use this Component for player punch Attacks")]
    [Header("Only For Player")]
    private PlayerAnimationController myPlayerAnimationController;
    private PlayerMovement myMovement;
    public AnimationClip myAnimation;
    public int damage;
    public Collider2D myCollider;
    public bool hitbox = false;
    public GameObject hitBoxObject;

    private void Awake()
    {
        myMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        if (myPlayerAnimationController == null)
        {
            myPlayerAnimationController = gameObject.GetComponent<PlayerAnimationController>();
        }
    }

    //gets called by any function that wants to start the attack animation
    public void BeginAttack()
    {

        myPlayerAnimationController.myAnimator.Play(myAnimation.name);

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
        myMovement.AllowMove(true);//unlock movement
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hitable hit = collision.gameObject.GetComponentInParent<Hitable>();
        PlayerHitable phitcheck = collision.gameObject.GetComponentInParent<PlayerHitable>();//double check we are not hitting an enemy, no friendly fire.

        if (hitbox && hit != null && phitcheck == null)
        {
            //we hit something hitable
            hit.GetHit(damage);
        }
    }
    */
    
}
