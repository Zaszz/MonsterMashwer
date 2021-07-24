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

        myAnimator.Play("AlienDeath");

    }

    public void Eat()
    {
        myAnimator.Play("SkeletonEating");
    }
}
