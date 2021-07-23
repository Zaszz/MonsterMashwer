using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator myAnimator;
    public AnimationClip DeathAnimation;

    public void PlayIdle()
    {

        myAnimator.Play("Movement");

    }

    public void PlayDie()
    {
        myAnimator.speed = 1f;
        myAnimator.Play("AlienDeath");

    }
}
