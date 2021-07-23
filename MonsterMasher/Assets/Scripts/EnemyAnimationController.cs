using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Animator myAnimator;
    public AnimationClip myIdleAnimation;


    public void PlayIdle()
    {
        myAnimator.Play("Movement");
    }

    public void PlayDie()
    {
        myAnimator.Play("AlienDeath");
    }
}
