using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Hitable : MonoBehaviour
{




    public virtual void GetHit(int damage)
    {
        //override this and do something with the damage you take.
    }
}
