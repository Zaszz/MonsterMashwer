using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator myAnimator;
    public AnimationClip myIdleAnimation;

    public void PlayIdle()
    {
        myAnimator.Play(myIdleAnimation.name);
    }
}
