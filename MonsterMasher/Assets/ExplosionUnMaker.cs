using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionUnMaker : MonoBehaviour
{
    public eyelaserexplode myexplode;

    public void DestroyParent()
    {
        myexplode.DestroyMe();
    }
}
