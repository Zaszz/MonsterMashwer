using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    public PlayerAttack myAttack;
    public PlayerMovement myMovement;
    public PlayerHitable myHitable;
    public bool attacking = false;
    private bool coroutine = false;

    private void StartAttack()
    {
        myMovement.AllowMove(false);
        myAttack.BeginAttack();
    }

    //this part gets called after the punch animation fires an event.
    public void EndAttack()
    {
        if (coroutine == false)
        {
            coroutine = true;
            StartCoroutine(WaitforAttackReady());
        }

    }

    IEnumerator WaitforAttackReady()
    {
        yield return new WaitForSeconds(0.1f);
        myMovement.AllowMove(true);
        coroutine = false;
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)  && myMovement.allowmove == true  && myHitable.hitstunned == false)
        {

            StartAttack();
        }


    }
}
