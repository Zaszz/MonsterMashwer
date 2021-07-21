using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator myAnimator;


    public void PlayIdle()
    {
        myAnimator.Play("Movement");
    }
}
