using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxTalker : MonoBehaviour
{
    public bool player = false;
    public PlayerAttack pAttack;
    public AttackController eAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Hitable hit = collision.gameObject.GetComponentInParent<Hitable>();
        PlayerHitable phitcheck = collision.gameObject.GetComponentInParent<PlayerHitable>();//double check we are not hitting an enemy, no friendly fire.

        if (player)
        {

            if (pAttack.hitbox && hit != null && phitcheck == null)
            {
                //we hit something hitable
                hit.GetHit(pAttack.damage);
            }
        }

        EnemyHitable ehitcheck = collision.gameObject.GetComponentInParent<EnemyHitable>();//double check we are not hitting an enemy, no friendly fire.

        if (player == false)
        {
            if (eAttack.hitbox && hit != null && ehitcheck == null)
            {
                //we hit a player and we are an enemy
                hit.GetHit(eAttack.damage);
            }
        }
    }
}
