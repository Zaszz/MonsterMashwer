using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    public PlayerAttack myAttack;
    public PlayerSpecialAttack mySpecial;
    public PlayerMovement myMovement;
    public PlayerHitable myHitable;
    public bool attacking = false;
    public bool eating = false;
    private bool coroutine = false;
    public List<GameObject> myCurrentEdibles = new List<GameObject>();


    private Heads newHead;
    private bool transforming = false;

    public void SetTransform(Heads head)
    {
        newHead = head;
        transforming = true;
    }

    private void StartAttack()
    {
        myMovement.AllowMove(false);
        myAttack.BeginAttack();
    }

    private void StartSpecial()
    {
        myMovement.AllowMove(false);
        mySpecial.BeginAttack();
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

    public void DoneEating()
    {
        //Debug.Log("Done Eating");
        eating = false;
        myMovement.myController.PlayIdle();
        myMovement.AllowMove(true);
        foreach (GameObject item in myCurrentEdibles)
        {
            Destroy(item);
        }
        if (transforming == true)
        {
            Vector3 currentposition = gameObject.transform.position;
            switch (newHead)
            {
                case Heads.Alien:
                    PlayerSuitManager.Instance.alien.transform.position = currentposition;
                    PlayerSuitManager.Instance.alien.SetActive(true);
                    PlayerSuitManager.Instance.alien.GetComponent<PlayerMovement>().AllowMove(true);
                    PlayerSuitManager.Instance.alien.GetComponent<PlayerHitable>().SetHealth(gameObject.GetComponent<PlayerHitable>().GetHealth());
                    PlayerManager.virtualCamera.Follow = PlayerSuitManager.Instance.alien.transform;
                    specialmanager.Instance.UpdateCharges(3);
                    gameObject.SetActive(false);
                    break;
                case Heads.Ape:
                    PlayerSuitManager.Instance.ape.transform.position = currentposition;
                    PlayerSuitManager.Instance.ape.SetActive(true);
                    PlayerSuitManager.Instance.ape.GetComponent<PlayerMovement>().AllowMove(true);
                    PlayerSuitManager.Instance.ape.GetComponent<PlayerHitable>().SetHealth(gameObject.GetComponent<PlayerHitable>().GetHealth());
                    PlayerManager.virtualCamera.Follow = PlayerSuitManager.Instance.ape.transform;
                    specialmanager.Instance.UpdateCharges(3);
                    gameObject.SetActive(false);
                    break;
                case Heads.Skeleton:
                    PlayerSuitManager.Instance.skeleton.transform.position = currentposition;
                    PlayerSuitManager.Instance.skeleton.SetActive(true);
                    PlayerSuitManager.Instance.skeleton.GetComponent<PlayerMovement>().AllowMove(true);
                    PlayerSuitManager.Instance.skeleton.GetComponent<PlayerHitable>().SetHealth(gameObject.GetComponent<PlayerHitable>().GetHealth());
                    PlayerManager.virtualCamera.Follow = PlayerSuitManager.Instance.skeleton.transform;
                    specialmanager.Instance.UpdateCharges(0);
                    gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            transforming = false;
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
        if (Input.GetKey(KeyCode.Space)  && myMovement.allowmove == true  && myHitable.hitstunned == false  && eating==false)
        {

            StartAttack();
        }

        if (Input.GetKey(KeyCode.Q) && myMovement.allowmove == true && myHitable.hitstunned == false && eating == false  && specialmanager.Instance.specialcharges>0)
        {
            StartSpecial();
        }
    }
}
