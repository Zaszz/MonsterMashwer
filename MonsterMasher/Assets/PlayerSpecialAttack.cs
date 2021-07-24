using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialAttack : MonoBehaviour
{
    private PlayerAnimationController myPlayerAnimationController;
    private PlayerMovement myMovement;
    [Header("Create a child object on the end of the barrel for the attack object to spawn from")]
    public GameObject SpawnPoint;
    public AnimationClip myAnimation;
    [Header("Put an object here that we spawn and does something on its own.")]
    public GameObject myAttackObject;

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

    public void BeginAttack()
    {
        myPlayerAnimationController.myAnimator.Play(myAnimation.name);
    }

    public void GotHit()
    {
        myMovement.AllowMove(true);//unlock movement
    }


    public void LaunchSpecial()
    {
        //called by animation events to spawn the attack object
        //spawn it at the spawn point and let it do its thing
        GameObject newObj = Instantiate(myAttackObject, SpawnPoint.transform.position, Quaternion.identity);
        EndSpecial();
    }

    private void EndSpecial()
    {
        specialmanager.Instance.ChangeCharges(-1);
    }

}
