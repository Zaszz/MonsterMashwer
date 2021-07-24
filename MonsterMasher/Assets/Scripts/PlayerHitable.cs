using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHitable : Hitable
{
    public List<PlayerAttack> myAttacks = new List<PlayerAttack>();
    public List<PlayerSpecialAttack> mySpecials = new List<PlayerSpecialAttack>();
    [SerializeField]
    private int myHealth;
    private PlayerAnimationController myPlayerAnimationController;
    private PlayerMasterController myMaster;
    public AnimationClip myHitClip;
    public bool hitstunned = false;
    public AudioSource source;
    public AudioClip hitnoise;

    public event Action Died;
    public int GetHealth()
    {
        return myHealth;
    }

    public void SetHealth(int newHp)
    {
        myHealth = newHp;
    }

    public void Heal()
    {
        myHealth += 1;
        if (myHealth > 5)
            myHealth = 5;
        HeartController.Instance.UpdateHealthUI(myHealth);
    }

    private void OnEnable()
    {
        if (myPlayerAnimationController == null)
        {
            myPlayerAnimationController = gameObject.GetComponent<PlayerAnimationController>();
        }

        if (myMaster == null)
        {
            myMaster = gameObject.GetComponent<PlayerMasterController>();
        }

        StartCoroutine("WaitForUpdateHealth");
    }

    IEnumerator WaitForUpdateHealth()
    {
        yield return new WaitForSeconds(0.1f);
        HeartController.Instance.UpdateHealthUI(myHealth);
    }

    public void EndHitStun()
    {

            hitstunned = false;


    }

    public override void GetHit(int damage)
    {
        //what to do when the enemy is hit

        if (hitstunned || gameObject.GetComponent<PlayerAttackInput>().eating)
        {//dont get hit while hit stunned  or eating
            return;
        }

        //for every attack we have make sure we turn off its events as we are now going to override with being hit.
        foreach (PlayerAttack item in myAttacks)
        {
            item.GotHit();
        }

        foreach (PlayerSpecialAttack item in mySpecials)
        {
            item.GotHit();
        }

        myHealth -= damage;
        source.clip = hitnoise;
        source.Play();
        if (myHealth > -1)
        {
            HeartController.Instance.UpdateHealthUI(myHealth);
        }
        hitstunned = true;

        if (myHealth > 0)
        {
            myPlayerAnimationController.myAnimator.Play(myHitClip.name);

        }
        else
        {
            StartCoroutine("GoToMain");
            Died?.Invoke();
            myMaster.playerMovement.allowmove = false;
            myMaster.playerAnimationController.PlayDie();
        }
    }

    IEnumerator GoToMain()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
