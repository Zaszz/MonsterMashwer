using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    public GameObject myItem;
    private bool subbed = false;

    private void Start()
    {
        if (subbed == false)
        {
            if (gameObject.GetComponent<EnemyHitable>() != null)
                gameObject.GetComponent<EnemyHitable>().Died += DropItem;
            if (gameObject.GetComponent<PlayerHitable>() != null)
                gameObject.GetComponent<PlayerHitable>().Died += DropItem;

            subbed = true;
        }
    }

    public void DropItem()
    {
        //Debug.Log("Dropping the fucking stupid cunt item FUCK YOU FUCK YOU FUCK YOU!!!!");
        myItem.SetActive(true);
        myItem.transform.SetParent(null);
    }
}
