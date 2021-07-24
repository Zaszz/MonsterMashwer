using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Heads{Alien,Ape, Skeleton }
public class HeadRegister : MonoBehaviour
{
    public Heads myHead;

    void Start()
    {
        switch (myHead)
        {
            case Heads.Alien:
                PickUpManager.Instance.aliens.Add(this.gameObject);
                break;
            case Heads.Ape:
                PickUpManager.Instance.apes.Add(this.gameObject);
                break;
            default:
                break;
        }

    }
}
