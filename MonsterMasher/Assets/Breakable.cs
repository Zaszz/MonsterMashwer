using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : Hitable
{
    public GameObject loot;
    public int health;
    public Animator myAnimator;

    public override void GetHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (loot != null)
            {
                loot.SetActive(true);
                loot.transform.SetParent(null);
            }
            myAnimator.Play("break");

        }
    }
}
