using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Devour : MonoBehaviour
{

    public float PickUpRange;
    public AudioClip eatnoise;
    public AudioSource source;
    public GameObject DevourText;
    public GameObject TransformText;
    public GameObject rightHand;
    private List<GameObject> localHearts = new List<GameObject>();
    private List<GameObject> localAliens = new List<GameObject>();
    private List<GameObject> localApes = new List<GameObject>();
    
    //check if we are in range of a devour.
    //if we are, throw up the UI element
    //if we are and we press E, play the animation, drop the element, and add the heart to health pool.
    private void Update()
    {
        if (PickUpManager.Instance.hearts.Count > 0)
        {
            localHearts.Clear();
            foreach (GameObject item in PickUpManager.Instance.hearts)
            {
                if (Vector3.Distance(item.transform.position, gameObject.transform.position) <= PickUpRange)
                {
                    localHearts.Add(item);
                }
            }

            if (localHearts.Count > 0)
            {
                ShowDevour();
            }
            else
            {
                HideDevour();
            }
        }

        if (PickUpManager.Instance.aliens.Count > 0)
        {
            localAliens.Clear();
            foreach (GameObject item in PickUpManager.Instance.aliens)
            {
                if (Vector3.Distance(item.transform.position, gameObject.transform.position) <= PickUpRange)
                {
                    localAliens.Add(item);
                }
            }

            if (localAliens.Count > 0)
            {
                ShowTransform();
            }
            else
            {
                HideTransform();
            }
        }
    }


    private void ShowTransform()
    {
        TransformText.SetActive(true);
        TransformAction();
    }

    private void HideTransform()
    {
        TransformText.SetActive(false);
    }

    private void TransformAction()
    {
        //if we press E and are not stun locked or attacking.  Only if we are moving or idle.
        if (Input.GetKey(KeyCode.E) && gameObject.GetComponent<PlayerAttackInput>().eating == false && gameObject.GetComponent<PlayerHitable>().hitstunned == false && gameObject.GetComponent<PlayerMovement>().allowmove == true)
        {
            //play the animation, lock out other animations.  Prevent attacking, allow moving.
            gameObject.GetComponent<PlayerAnimationController>().Eat();
            source.clip = eatnoise;
            source.Play();
            gameObject.GetComponent<PlayerAttackInput>().eating = true;//set this to false with an event.
            if (localAliens.Count > 0)
            {
                gameObject.GetComponent<PlayerAttackInput>().SetTransform(Heads.Alien);
                HideTransform();
                foreach (GameObject item in localAliens)
                {
                    item.transform.position = rightHand.transform.position;
                    item.transform.SetParent(rightHand.transform);
                    PickUpManager.Instance.aliens.Remove(item);
                    gameObject.GetComponent<PlayerAttackInput>().myCurrentEdibles.Add(item);
                }
            }
            if (localApes.Count > 0)
            {
                gameObject.GetComponent<PlayerAttackInput>().SetTransform(Heads.Ape);
                foreach (GameObject item in localApes)
                {
                    item.transform.position = rightHand.transform.position;
                    item.transform.SetParent(rightHand.transform);
                    PickUpManager.Instance.aliens.Remove(item);
                    gameObject.GetComponent<PlayerAttackInput>().myCurrentEdibles.Add(item);
                }
            }


            
        }
    }

    private void DevourAction()
    {
        //if we press E and are not stun locked or attacking.  Only if we are moving or idle.
        if (Input.GetKey(KeyCode.E) && gameObject.GetComponent<PlayerAttackInput>().eating == false && gameObject.GetComponent<PlayerHitable>().hitstunned == false && gameObject.GetComponent<PlayerMovement>().allowmove == true)
        {
            //play the animation, lock out other animations.  Prevent attacking, allow moving.
            gameObject.GetComponent<PlayerAnimationController>().Eat();
            source.clip = eatnoise;
            source.Play();
            gameObject.GetComponent<PlayerAttackInput>().eating = true;//set this to false with an event.
                                                                       //apply the new heart.
            gameObject.GetComponent<PlayerHitable>().Heal();
            HideDevour();
            foreach (GameObject item in localHearts)
            {
                item.transform.position = rightHand.transform.position;
                item.transform.SetParent(rightHand.transform);
                PickUpManager.Instance.hearts.Remove(item);
                gameObject.GetComponent<PlayerAttackInput>().myCurrentEdibles.Add(item);
            }
        }
    }

    private void ShowDevour()
    {
        DevourText.SetActive(true);
        DevourAction();
    }

    private void HideDevour()
    {
        DevourText.SetActive(false);
    }
}
